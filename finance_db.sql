-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3308
-- Generation Time: Apr 13, 2026 at 09:09 AM
-- Server version: 8.3.0
-- PHP Version: 8.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `finance_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
CREATE TABLE IF NOT EXISTS `accounts` (
  `AccountID` int NOT NULL AUTO_INCREMENT,
  `Balance` decimal(15,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`AccountID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`AccountID`, `Balance`) VALUES
(1, 9690.00);

-- --------------------------------------------------------

--
-- Table structure for table `applogs`
--

DROP TABLE IF EXISTS `applogs`;
CREATE TABLE IF NOT EXISTS `applogs` (
  `LogID` int NOT NULL AUTO_INCREMENT,
  `UserID` int DEFAULT NULL,
  `Action` varchar(50) NOT NULL,
  `Details` varchar(400) DEFAULT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`LogID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
CREATE TABLE IF NOT EXISTS `departments` (
  `DeptID` int NOT NULL AUTO_INCREMENT,
  `DeptName` varchar(100) NOT NULL,
  `FiscalYear` int NOT NULL,
  `Budget` decimal(18,2) NOT NULL,
  PRIMARY KEY (`DeptID`),
  UNIQUE KEY `DeptName` (`DeptName`)
) ;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`DeptID`, `DeptName`, `FiscalYear`, `Budget`) VALUES
(1, 'Finance', 2025, 50000.00);

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
CREATE TABLE IF NOT EXISTS `employees` (
  `EmployeeID` varchar(20) NOT NULL,
  `FullName` varchar(120) NOT NULL,
  `Department` varchar(100) DEFAULT NULL,
  `Position` varchar(100) DEFAULT NULL,
  `DateJoined` date DEFAULT NULL,
  PRIMARY KEY (`EmployeeID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`EmployeeID`, `FullName`, `Department`, `Position`, `DateJoined`) VALUES
('XE2435', 'Davis Cotley', 'HR', 'User', '2025-09-20'),
('XE4353667', 'Malo Ndoro', 'IT', 'Admin', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `expenses`
--

DROP TABLE IF EXISTS `expenses`;
CREATE TABLE IF NOT EXISTS `expenses` (
  `id` int NOT NULL AUTO_INCREMENT,
  `expense_name` varchar(200) NOT NULL,
  `amount` decimal(12,2) NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `status` enum('Pending','Approved','Resolved','Rejected','Declined') NOT NULL DEFAULT 'Pending',
  `updated_by` varchar(120) DEFAULT NULL,
  `payment_method` varchar(50) DEFAULT 'Cash',
  `created_by` varchar(120) NOT NULL,
  `CreatedBy` int DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_expenses_createdby` (`CreatedBy`),
  KEY `fk_expenses_updatedby` (`UpdatedBy`)
) ENGINE=MyISAM AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `expenses`
--

INSERT INTO `expenses` (`id`, `expense_name`, `amount`, `created_at`, `status`, `updated_by`, `payment_method`, `created_by`, `CreatedBy`, `UpdatedBy`) VALUES
(17, 'Motor vehicle repairs', 25.00, '2025-12-30 12:46:02', 'Pending', NULL, 'Cash', '5', NULL, NULL),
(4, 'Hardware and Accessories', 75.00, '2025-09-13 22:43:01', 'Declined', '6', 'Cash', '5', NULL, 5),
(7, '4646337', 56.00, '2025-09-15 13:29:13', 'Declined', '6', 'Cash', '7', NULL, 5),
(8, 'Materials', 64.00, '2025-09-15 14:40:49', 'Pending', NULL, 'Cash', '7', NULL, NULL),
(9, 'Accessories', 50.00, '2025-09-19 13:22:49', 'Pending', NULL, 'Cash', '7', NULL, NULL),
(12, 'Stationery', 30.00, '2025-09-19 13:40:18', 'Pending', NULL, 'Cash', '5', NULL, NULL),
(13, 'Dinner', 25.00, '2025-09-20 00:33:43', 'Pending', NULL, 'Cash', '9', NULL, NULL),
(14, 'Airtime', 40.00, '2025-09-20 01:52:02', 'Pending', NULL, 'Cash', '9', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `EmployeeID` varchar(20) DEFAULT NULL,
  `FullName` varchar(150) NOT NULL,
  `Email` varchar(120) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Role` enum('User','FinanceManager','Admin') DEFAULT 'User',
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `Email` (`Email`),
  UNIQUE KEY `EmployeeID` (`EmployeeID`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `EmployeeID`, `FullName`, `Email`, `Password`, `Role`, `IsActive`) VALUES
(1, 'XE001', 'System Admin', 'admin@example.com', 'admin123', 'Admin', 1),
(5, 'XE23455', 'John Doe', 'jdoe@gmail.com', 'johndoe', 'Admin', 1),
(6, 'XE5866', 'Sam Lee', 'sam@gmail.com', 'manager', 'FinanceManager', 1),
(7, 'XE3456', 'Dan Mall', 'dmall@gmail.com', 'mall', 'User', 1),
(8, 'XE46474737', 'Davis Green', 'dgreen@gmail.com', 'green5', 'Admin', 1),
(9, 'XE347474', 'Fin Mall', 'fmall@gmail.com', 'danmall5', 'User', 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
