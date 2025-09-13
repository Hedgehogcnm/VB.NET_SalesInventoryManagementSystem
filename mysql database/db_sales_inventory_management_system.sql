-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 13, 2025 at 12:17 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_sales_inventory_management_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `tb_inventorymovements`
--

CREATE TABLE `tb_inventorymovements` (
  `im_id` int(11) NOT NULL,
  `p_id` int(11) NOT NULL,
  `im_type` enum('sales','purchase','adjust') NOT NULL,
  `im_ref_id` int(11) DEFAULT NULL,
  `im_qtyChange` int(11) NOT NULL,
  `im_dateTime` datetime DEFAULT current_timestamp(),
  `im_note` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_orders`
--

CREATE TABLE `tb_orders` (
  `o_id` int(11) NOT NULL,
  `p_id` int(11) NOT NULL,
  `u_id` int(11) NOT NULL,
  `sup_id` int(11) NOT NULL,
  `o_qty` int(11) NOT NULL CHECK (`o_qty` > 0),
  `o_total` decimal(10,2) NOT NULL,
  `o_status` enum('ordered','received','cancelled') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Triggers `tb_orders`
--
DELIMITER $$
CREATE TRIGGER `trg_update_im_after_o_received` AFTER UPDATE ON `tb_orders` FOR EACH ROW BEGIN
  IF NEW.o_status = 'received' AND OLD.o_status <> 'received' THEN
    -- increase stock
    UPDATE tb_products
    SET p_stock = p_stock + NEW.o_qty
    WHERE p_id = NEW.p_id;

    -- record movement
    INSERT INTO tb_inventoryMovements(p_id, im_type, im_ref_id, im_qtyChange, im_note)
    VALUES (NEW.p_id, 'purchase', NEW.o_id, NEW.o_qty, 'Stock received from order');
  END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `tb_products`
--

CREATE TABLE `tb_products` (
  `p_id` int(11) NOT NULL,
  `sup_id` int(11) DEFAULT NULL,
  `p_name` varchar(200) NOT NULL,
  `p_category` enum('Hand Tools','Power Tools','Plumbing','Electrical','Building Materials','Paint & Adhesives','Safety Equipment') NOT NULL,
  `p_stock` int(11) DEFAULT 0,
  `p_minStock` int(11) DEFAULT 0,
  `p_costPrice` decimal(10,2) NOT NULL,
  `p_sellPrice` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tb_products`
--

INSERT INTO `tb_products` (`p_id`, `sup_id`, `p_name`, `p_category`, `p_stock`, `p_minStock`, `p_costPrice`, `p_sellPrice`) VALUES
(1, 1, 'Hammer (16oz claw hammer)', 'Hand Tools', 50, 10, 15.00, 25.00),
(2, 1, 'Screwdriver Set (flat + Phillips)', 'Hand Tools', 40, 10, 20.00, 35.00),
(3, 1, 'Adjustable Wrench (10 inch)', 'Hand Tools', 30, 5, 18.00, 30.00),
(4, 2, 'Electric Drill (500W)', 'Power Tools', 20, 5, 120.00, 180.00),
(5, 2, 'Angle Grinder (4 inch)', 'Power Tools', 15, 5, 100.00, 160.00),
(6, 2, 'Circular Saw (7 inch)', 'Power Tools', 10, 3, 150.00, 220.00),
(7, 3, 'PVC Pipe (1 inch, 3m length)', 'Plumbing', 60, 15, 12.00, 20.00),
(8, 3, 'Faucet Tap (brass)', 'Plumbing', 30, 10, 25.00, 40.00),
(9, 3, 'Pipe Fittings (elbow joint, 90°)', 'Plumbing', 50, 15, 5.00, 12.00),
(10, 1, 'Electrical Wire (10m, 1.5mm)', 'Electrical', 80, 20, 30.00, 50.00),
(11, 1, 'Light Switch (single pole)', 'Electrical', 100, 20, 8.00, 15.00),
(12, 1, 'LED Bulb (9W, E27)', 'Electrical', 120, 30, 6.00, 12.00),
(13, 3, 'Cement Bag (50kg)', 'Building Materials', 40, 10, 20.00, 35.00),
(14, 3, 'Plywood Sheet (4x8 feet, 12mm)', 'Building Materials', 25, 5, 55.00, 90.00),
(15, 3, 'Red Bricks (standard size)', 'Building Materials', 500, 100, 0.30, 0.70),
(16, 3, 'Wall Paint (5L, white)', 'Paint & Adhesives', 35, 10, 60.00, 95.00),
(17, 3, 'Paint Brush (2 inch)', 'Paint & Adhesives', 60, 15, 5.00, 10.00),
(18, 3, 'Super Glue (cyanoacrylate)', 'Paint & Adhesives', 100, 20, 2.00, 5.00),
(19, 2, 'Safety Helmet (yellow)', 'Safety Equipment', 40, 10, 18.00, 30.00),
(20, 2, 'Safety Gloves (rubber-coated)', 'Safety Equipment', 60, 15, 5.00, 12.00),
(21, 2, 'Safety Goggles (clear lens)', 'Safety Equipment', 50, 10, 12.00, 20.00);

--
-- Triggers `tb_products`
--
DELIMITER $$
CREATE TRIGGER `trg_update_im_after_p_update` AFTER UPDATE ON `tb_products` FOR EACH ROW BEGIN
  IF NEW.p_stock <> OLD.p_stock THEN
    INSERT INTO tb_inventoryMovements(p_id, im_type, im_ref_id, im_qtyChange, im_note)
    VALUES (NEW.p_id, 'adjust', NULL, NEW.p_stock - OLD.p_stock, 'Manual stock adjustment');
  END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `tb_sales`
--

CREATE TABLE `tb_sales` (
  `s_id` int(11) NOT NULL,
  `u_id` int(11) NOT NULL,
  `s_invoiceNo` varchar(30) NOT NULL,
  `s_dateTime` datetime DEFAULT current_timestamp(),
  `s_customer` varchar(200) DEFAULT NULL,
  `s_total` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_sales_detail`
--

CREATE TABLE `tb_sales_detail` (
  `sd_id` int(11) NOT NULL,
  `s_id` int(11) NOT NULL,
  `p_id` int(11) NOT NULL,
  `sd_qty` int(11) NOT NULL CHECK (`sd_qty` > 0),
  `sd_total` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Triggers `tb_sales_detail`
--
DELIMITER $$
CREATE TRIGGER `trg_update_im_after_sd_delete` AFTER DELETE ON `tb_sales_detail` FOR EACH ROW BEGIN
  -- restore stock
  UPDATE tb_products
  SET p_stock = p_stock + OLD.sd_qty
  WHERE p_id = OLD.p_id;

  -- record movement
  INSERT INTO tb_inventoryMovements(p_id, im_type, im_ref_id, im_qtyChange, im_note)
  VALUES (OLD.p_id, 'adjust', OLD.s_id, OLD.sd_qty, 'Rollback sale deletion');
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_update_im_after_sd_insert` AFTER INSERT ON `tb_sales_detail` FOR EACH ROW BEGIN
  -- decrease stock
  UPDATE tb_products
  SET p_stock = p_stock - NEW.sd_qty
  WHERE p_id = NEW.p_id;

  -- record movement
  INSERT INTO tb_inventoryMovements(p_id, im_type, im_ref_id, im_qtyChange, im_note)
  VALUES (NEW.p_id, 'sales', NEW.s_id, -NEW.sd_qty, 'Auto reduce after sale');
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_update_total_before_sd_insert` BEFORE INSERT ON `tb_sales_detail` FOR EACH ROW BEGIN
  DECLARE price DECIMAL(10,2);
  
  -- get current selling price
  SELECT p_sellPrice INTO price FROM tb_products WHERE p_id = NEW.p_id;
  
  -- calculate total
  SET NEW.sd_total = NEW.sd_qty * price;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `tb_suppliers`
--

CREATE TABLE `tb_suppliers` (
  `sup_id` int(11) NOT NULL,
  `sup_name` varchar(200) NOT NULL,
  `sup_contact` varchar(50) DEFAULT NULL,
  `sup_email` varchar(120) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tb_suppliers`
--

INSERT INTO `tb_suppliers` (`sup_id`, `sup_name`, `sup_contact`, `sup_email`) VALUES
(1, 'BuildMart Hardware Supplies', '012-3456789', 'contact@buildmart.com'),
(2, 'ToolPro Industrial Co.', '013-9876543', 'sales@toolpro.com'),
(3, 'MegaConstruct Materials', '014-2233445', 'info@megaconstruct.com');

-- --------------------------------------------------------

--
-- Table structure for table `tb_users`
--

CREATE TABLE `tb_users` (
  `u_id` int(11) NOT NULL,
  `u_name` varchar(100) NOT NULL,
  `u_password` varchar(255) NOT NULL,
  `u_role` enum('admin','staff') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tb_users`
--

INSERT INTO `tb_users` (`u_id`, `u_name`, `u_password`, `u_role`) VALUES
(1, 'admin', '12345', 'admin'),
(2, 'staff', '12345', 'staff');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_inventorymovements`
--
ALTER TABLE `tb_inventorymovements`
  ADD PRIMARY KEY (`im_id`),
  ADD KEY `p_id` (`p_id`);

--
-- Indexes for table `tb_orders`
--
ALTER TABLE `tb_orders`
  ADD PRIMARY KEY (`o_id`),
  ADD KEY `p_id` (`p_id`),
  ADD KEY `u_id` (`u_id`),
  ADD KEY `sup_id` (`sup_id`);

--
-- Indexes for table `tb_products`
--
ALTER TABLE `tb_products`
  ADD PRIMARY KEY (`p_id`),
  ADD KEY `sup_id` (`sup_id`);

--
-- Indexes for table `tb_sales`
--
ALTER TABLE `tb_sales`
  ADD PRIMARY KEY (`s_id`),
  ADD UNIQUE KEY `s_invoiceNo` (`s_invoiceNo`),
  ADD KEY `u_id` (`u_id`);

--
-- Indexes for table `tb_sales_detail`
--
ALTER TABLE `tb_sales_detail`
  ADD PRIMARY KEY (`sd_id`),
  ADD KEY `s_id` (`s_id`),
  ADD KEY `p_id` (`p_id`);

--
-- Indexes for table `tb_suppliers`
--
ALTER TABLE `tb_suppliers`
  ADD PRIMARY KEY (`sup_id`);

--
-- Indexes for table `tb_users`
--
ALTER TABLE `tb_users`
  ADD PRIMARY KEY (`u_id`),
  ADD UNIQUE KEY `u_name` (`u_name`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_inventorymovements`
--
ALTER TABLE `tb_inventorymovements`
  MODIFY `im_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_orders`
--
ALTER TABLE `tb_orders`
  MODIFY `o_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_products`
--
ALTER TABLE `tb_products`
  MODIFY `p_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `tb_sales`
--
ALTER TABLE `tb_sales`
  MODIFY `s_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_sales_detail`
--
ALTER TABLE `tb_sales_detail`
  MODIFY `sd_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_suppliers`
--
ALTER TABLE `tb_suppliers`
  MODIFY `sup_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tb_users`
--
ALTER TABLE `tb_users`
  MODIFY `u_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tb_inventorymovements`
--
ALTER TABLE `tb_inventorymovements`
  ADD CONSTRAINT `tb_inventorymovements_ibfk_1` FOREIGN KEY (`p_id`) REFERENCES `tb_products` (`p_id`);

--
-- Constraints for table `tb_orders`
--
ALTER TABLE `tb_orders`
  ADD CONSTRAINT `tb_orders_ibfk_1` FOREIGN KEY (`p_id`) REFERENCES `tb_products` (`p_id`),
  ADD CONSTRAINT `tb_orders_ibfk_2` FOREIGN KEY (`u_id`) REFERENCES `tb_users` (`u_id`),
  ADD CONSTRAINT `tb_orders_ibfk_3` FOREIGN KEY (`sup_id`) REFERENCES `tb_suppliers` (`sup_id`);

--
-- Constraints for table `tb_products`
--
ALTER TABLE `tb_products`
  ADD CONSTRAINT `tb_products_ibfk_1` FOREIGN KEY (`sup_id`) REFERENCES `tb_suppliers` (`sup_id`);

--
-- Constraints for table `tb_sales`
--
ALTER TABLE `tb_sales`
  ADD CONSTRAINT `tb_sales_ibfk_1` FOREIGN KEY (`u_id`) REFERENCES `tb_users` (`u_id`);

--
-- Constraints for table `tb_sales_detail`
--
ALTER TABLE `tb_sales_detail`
  ADD CONSTRAINT `tb_sales_detail_ibfk_1` FOREIGN KEY (`s_id`) REFERENCES `tb_sales` (`s_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `tb_sales_detail_ibfk_2` FOREIGN KEY (`p_id`) REFERENCES `tb_products` (`p_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
