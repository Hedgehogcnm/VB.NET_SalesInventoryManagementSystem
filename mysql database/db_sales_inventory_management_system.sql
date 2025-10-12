-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 12, 2025 at 02:36 AM
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

--
-- Dumping data for table `tb_inventorymovements`
--

INSERT INTO `tb_inventorymovements` (`im_id`, `p_id`, `im_type`, `im_ref_id`, `im_qtyChange`, `im_dateTime`, `im_note`) VALUES
(1, 1, 'adjust', NULL, -2, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(2, 1, 'sales', 1, -2, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(3, 4, 'adjust', NULL, -1, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(4, 4, 'sales', 2, -1, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(5, 5, 'adjust', NULL, -1, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(6, 5, 'sales', 3, -1, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(7, 9, 'adjust', NULL, -3, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(8, 9, 'sales', 4, -3, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(9, 10, 'adjust', NULL, -4, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(10, 10, 'sales', 5, -4, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(11, 12, 'adjust', NULL, -10, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(12, 12, 'sales', 6, -10, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(13, 14, 'adjust', NULL, -2, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(14, 14, 'sales', 7, -2, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(15, 16, 'adjust', NULL, -1, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(16, 16, 'sales', 8, -1, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(17, 18, 'adjust', NULL, -1, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(18, 18, 'sales', 9, -1, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(19, 21, 'adjust', NULL, -2, '2025-10-10 16:13:30', 'Manual stock adjustment'),
(20, 21, 'sales', 10, -2, '2025-10-10 16:13:30', 'Auto reduce after sale'),
(21, 1, 'adjust', NULL, -2, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(22, 1, 'sales', 1, -2, '2025-10-10 16:17:52', 'Auto reduce after sale'),
(23, 4, 'adjust', NULL, -1, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(24, 4, 'sales', 2, -1, '2025-10-10 16:17:52', 'Auto reduce after sale'),
(25, 5, 'adjust', NULL, -1, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(26, 5, 'sales', 3, -1, '2025-10-10 16:17:52', 'Auto reduce after sale'),
(27, 9, 'adjust', NULL, -3, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(28, 9, 'sales', 4, -3, '2025-10-10 16:17:52', 'Auto reduce after sale'),
(29, 10, 'adjust', NULL, -4, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(30, 10, 'sales', 5, -4, '2025-10-10 16:17:52', 'Auto reduce after sale'),
(31, 12, 'adjust', NULL, -10, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(32, 12, 'sales', 6, -10, '2025-10-10 16:17:52', 'Auto reduce after sale'),
(33, 14, 'adjust', NULL, -2, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(34, 14, 'sales', 7, -2, '2025-10-10 16:17:52', 'Auto reduce after sale'),
(35, 16, 'adjust', NULL, -1, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(36, 16, 'sales', 8, -1, '2025-10-10 16:17:52', 'Auto reduce after sale'),
(37, 18, 'adjust', NULL, -1, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(38, 18, 'sales', 9, -1, '2025-10-10 16:17:52', 'Auto reduce after sale'),
(39, 21, 'adjust', NULL, -2, '2025-10-10 16:17:52', 'Manual stock adjustment'),
(40, 21, 'sales', 10, -2, '2025-10-10 16:17:52', 'Auto reduce after sale');

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
-- Dumping data for table `tb_orders`
--

INSERT INTO `tb_orders` (`o_id`, `p_id`, `u_id`, `sup_id`, `o_qty`, `o_total`, `o_status`) VALUES
(1, 1, 2, 1, 50, 750.00, ''),
(2, 4, 2, 2, 20, 2400.00, ''),
(3, 5, 2, 2, 10, 1000.00, ''),
(4, 10, 2, 3, 30, 1500.00, ''),
(5, 12, 2, 4, 100, 600.00, ''),
(6, 14, 2, 3, 10, 900.00, ''),
(7, 16, 2, 2, 10, 950.00, ''),
(8, 18, 2, 5, 5, 150.00, ''),
(9, 19, 2, 5, 8, 240.00, ''),
(10, 21, 2, 6, 20, 400.00, '');

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
(1, 1, 'Hammer (16oz claw hammer)', 'Hand Tools', 46, 10, 15.00, 25.00),
(2, 1, 'Screwdriver Set (flat + Phillips)', 'Hand Tools', 40, 10, 20.00, 35.00),
(3, 1, 'Adjustable Wrench (10 inch)', 'Hand Tools', 30, 5, 18.00, 30.00),
(4, 2, 'Electric Drill (500W)', 'Power Tools', 18, 5, 120.00, 180.00),
(5, 2, 'Angle Grinder (4 inch)', 'Power Tools', 13, 5, 100.00, 160.00),
(6, 2, 'Circular Saw (7 inch)', 'Power Tools', 10, 3, 150.00, 220.00),
(7, 3, 'PVC Pipe (1 inch, 3m length)', 'Plumbing', 60, 15, 12.00, 20.00),
(8, 3, 'Faucet Tap (brass)', 'Plumbing', 30, 10, 25.00, 40.00),
(9, 3, 'Pipe Fittings (elbow joint, 90°)', 'Plumbing', 44, 15, 5.00, 12.00),
(10, 1, 'Electrical Wire (10m, 1.5mm)', 'Electrical', 72, 20, 30.00, 50.00),
(11, 1, 'Light Switch (single pole)', 'Electrical', 100, 20, 8.00, 15.00),
(12, 1, 'LED Bulb (9W, E27)', 'Electrical', 100, 30, 6.00, 12.00),
(13, 3, 'Cement Bag (50kg)', 'Building Materials', 40, 10, 20.00, 35.00),
(14, 3, 'Plywood Sheet (4x8 feet, 12mm)', 'Building Materials', 21, 5, 55.00, 90.00),
(15, 3, 'Red Bricks (standard size)', 'Building Materials', 500, 100, 0.30, 0.70),
(16, 3, 'Wall Paint (5L, white)', 'Paint & Adhesives', 33, 10, 60.00, 95.00),
(17, 3, 'Paint Brush (2 inch)', 'Paint & Adhesives', 60, 15, 5.00, 10.00),
(18, 3, 'Super Glue (cyanoacrylate)', 'Paint & Adhesives', 98, 20, 2.00, 5.00),
(19, 2, 'Safety Helmet (yellow)', 'Safety Equipment', 40, 10, 18.00, 30.00),
(20, 2, 'Safety Gloves (rubber-coated)', 'Safety Equipment', 60, 15, 5.00, 12.00),
(21, 2, 'Safety Goggles (clear lens)', 'Safety Equipment', 46, 10, 12.00, 20.00);

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

--
-- Dumping data for table `tb_sales`
--

INSERT INTO `tb_sales` (`s_id`, `u_id`, `s_invoiceNo`, `s_dateTime`, `s_customer`, `s_total`) VALUES
(1, 2, 'INV20251010001', '2025-10-01 10:15:00', 'John Tan', 85.50),
(2, 2, 'INV20251010002', '2025-10-01 11:40:00', 'Alice Lim', 125.00),
(3, 2, 'INV20251010003', '2025-10-02 09:20:00', 'Muhd Amir', 49.90),
(4, 2, 'INV20251010004', '2025-10-03 14:35:00', 'Rachel Wong', 230.75),
(5, 2, 'INV20251010005', '2025-10-04 08:45:00', 'Jason Lee', 310.00),
(6, 2, 'INV20251010006', '2025-10-05 16:25:00', 'Alice Lim', 129.99),
(7, 2, 'INV20251010007', '2025-10-06 12:00:00', 'John Tan', 150.00),
(8, 2, 'INV20251010008', '2025-10-07 17:10:00', 'Muhd Amir', 200.50),
(9, 2, 'INV20251010009', '2025-10-08 15:45:00', 'Rachel Wong', 175.25),
(10, 2, 'INV20251010010', '2025-10-09 09:55:00', 'Jason Lee', 98.00);

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
-- Dumping data for table `tb_sales_detail`
--

INSERT INTO `tb_sales_detail` (`sd_id`, `s_id`, `p_id`, `sd_qty`, `sd_total`) VALUES
(1, 1, 1, 2, 50.00),
(2, 2, 4, 1, 180.00),
(3, 3, 5, 1, 160.00),
(4, 4, 9, 3, 36.00),
(5, 5, 10, 4, 200.00),
(6, 6, 12, 10, 120.00),
(7, 7, 14, 2, 180.00),
(8, 8, 16, 1, 95.00),
(9, 9, 18, 1, 5.00),
(10, 10, 21, 2, 40.00);

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
  `sup_email` varchar(120) DEFAULT NULL,
  `status` enum('Active','Inactive') DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tb_suppliers`
--

INSERT INTO `tb_suppliers` (`sup_id`, `sup_name`, `sup_contact`, `sup_email`, `status`) VALUES
(1, 'BuildMart Hardware Supplies', '012-3456789', 'contact@buildmart.com', 'Inactive'),
(2, 'ToolPro Industrial Co.', '013-9876543', 'sales@toolpro.com', 'Active'),
(3, 'MegaConstruct Materials', '014-2233445', 'info@megaconstruct.com', 'Active'),
(4, 'Beta Hardware Ltd.', '018-12345678', 'info@betahardware.com', 'Inactive'),
(5, 'Gamma Supplies', '019-3333444', 'contact@gammasupplies.com', 'Active'),
(6, 'Yap Inventory Sdn Bhd', '011-12334751', 'yap@gmail.com', 'Active');

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
  MODIFY `im_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `tb_orders`
--
ALTER TABLE `tb_orders`
  MODIFY `o_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tb_products`
--
ALTER TABLE `tb_products`
  MODIFY `p_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `tb_sales`
--
ALTER TABLE `tb_sales`
  MODIFY `s_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tb_sales_detail`
--
ALTER TABLE `tb_sales_detail`
  MODIFY `sd_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tb_suppliers`
--
ALTER TABLE `tb_suppliers`
  MODIFY `sup_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

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
