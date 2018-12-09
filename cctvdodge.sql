-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 09, 2018 at 09:10 AM
-- Server version: 10.1.16-MariaDB
-- PHP Version: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cctvdodge`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `username` varchar(500) NOT NULL,
  `password` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_admin`
--

INSERT INTO `tbl_admin` (`username`, `password`) VALUES
('ryan', 'AFYg8a6xu/E=');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_operations`
--

CREATE TABLE `tbl_operations` (
  `operation_id` varchar(500) NOT NULL,
  `date_started` varchar(50) NOT NULL,
  `contract_name` varchar(500) NOT NULL,
  `client` varchar(500) NOT NULL,
  `location` varchar(500) NOT NULL,
  `contact` varchar(500) NOT NULL,
  `work_nature` varchar(500) NOT NULL,
  `description` varchar(500) NOT NULL,
  `contract_amount` varchar(500) NOT NULL,
  `status` varchar(500) NOT NULL,
  `date_finished` varchar(50) NOT NULL,
  `duration` varchar(100) NOT NULL,
  `completion_amount` varchar(500) NOT NULL,
  `completion_percent` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_operations`
--

INSERT INTO `tbl_operations` (`operation_id`, `date_started`, `contract_name`, `client`, `location`, `contact`, `work_nature`, `description`, `contract_amount`, `status`, `date_finished`, `duration`, `completion_amount`, `completion_percent`) VALUES
('OPR001', '1/17/2017', 'ESTABLISHMENT AND SET-UP OF A CENTRALIZE SECURITY SURVEILLANCE SYSTEM PHASE 1', 'ASIA ALSTRON MINING AND DEVELOPTMENT CORPORATION and PHIL ALSTRON MINING CORPORATION', 'Barangay Tagmamarkay Tubay, Agusan Del Norte', '0917-718-1869', 'Mining Site Installation for Safety and Security 24/7, that is can be monitored in a centralized set-up in wireless environment', 'As per agreed set-up and installation, design implement the project with full training of conerned personnel to utilized the used of the technology at hand', 'Php 1,226,946.00', 'Completed', '10/8/2017', '264 working days', 'Php 1,226,946.00', '100 %'),
('OPR002', '11/7/2017', 'sdfrga', 'drfg', 'dsfds', '508056', 'dsgs', 'dfbfd', 'Php Php 5,785.00', 'Completed', '11/7/2017', '1 working day', 'Php 5,785.00', '100 %'),
('OPR003', '1/31/2018', 'bla bla bla', 'bla bla bla', 'bla bla bla', '0926464', 'bla bla blabla bla blabla bla bla', 'bla bla blabla bla bla', 'Php Php 1,000,000.00', 'Completed', '1/31/2018', '1 working day', 'Php 1,000,000.00', '100%');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_operation_assigned_personel`
--

CREATE TABLE `tbl_operation_assigned_personel` (
  `operation_id` varchar(500) NOT NULL,
  `fullname` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_operation_assigned_personel`
--

INSERT INTO `tbl_operation_assigned_personel` (`operation_id`, `fullname`) VALUES
('OPR001', 'Ian'),
('OPR001', 'Jazheel'),
('OPR002', 'Ian'),
('OPR002', 'Jazheel'),
('OPR002', 'Jubeth Ligtas Alag'),
('OPR002', 'Rhemon'),
('OPR002', 'Ricky'),
('OPR002', 'Ryan Empleo Esper'),
('OPR003', 'Jazheel'),
('OPR003', 'Jubeth Ligtas Alag'),
('OPR003', 'Ricky'),
('OPR003', 'Ryan Empleo Esper');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_operation_item_total`
--

CREATE TABLE `tbl_operation_item_total` (
  `operation_id` varchar(500) NOT NULL,
  `qty` varchar(500) NOT NULL,
  `quantity` varchar(500) NOT NULL,
  `items` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_operation_item_total`
--

INSERT INTO `tbl_operation_item_total` (`operation_id`, `qty`, `quantity`, `items`) VALUES
('OPR001', '1', '1 unit', 'Camera (Bullet IP)'),
('OPR001', '1', '1 unit', 'Hard Drive'),
('OPR001', '2', '2 unit', 'Camera (Bullet Analogue)'),
('OPR001', '2', '2 pcs', 'HDMI Cable (5 meters)'),
('OPR001', '400', '400 meters', 'Cable (Coaxial)'),
('OPR001', '5', '5 pcs', 'VGA Cable (VGA)'),
('OPR002', '1', '1 unit', 'Camera (Dome Analogue)'),
('OPR002', '1', '1 unit', 'Camera (Bullet Analogue)'),
('OPR002', '3', '3 unit', 'Camera (Bullet IP)'),
('OPR003', '1', '1 unit', 'Switch (Power Switch)'),
('OPR003', '100', '100 meters', 'Cable (Coaxial)'),
('OPR003', '3', '3 pcs', 'HDMI Cable (5 meters)');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_operation_item_used`
--

CREATE TABLE `tbl_operation_item_used` (
  `operation_id` varchar(500) NOT NULL,
  `product_id` varchar(500) NOT NULL,
  `product` varchar(500) NOT NULL,
  `type` varchar(500) NOT NULL,
  `brand` varchar(500) NOT NULL,
  `supplier` varchar(500) NOT NULL,
  `serial` varchar(500) DEFAULT NULL,
  `model` varchar(500) NOT NULL,
  `arrival_date` varchar(500) NOT NULL,
  `quantity` varchar(500) NOT NULL,
  `unit` varchar(500) NOT NULL,
  `unit_price` decimal(65,2) NOT NULL,
  `selling_price` decimal(65,2) NOT NULL,
  `quantity_unit` varchar(500) NOT NULL,
  `total_price` decimal(65,2) NOT NULL,
  `specification` varchar(5000) NOT NULL,
  `status` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_operation_item_used`
--

INSERT INTO `tbl_operation_item_used` (`operation_id`, `product_id`, `product`, `type`, `brand`, `supplier`, `serial`, `model`, `arrival_date`, `quantity`, `unit`, `unit_price`, `selling_price`, `quantity_unit`, `total_price`, `specification`, `status`) VALUES
('OPR001', 'v2PROD001', 'Cable', 'Coaxial', '', 'Electronics', NULL, '', '10/6/2017', '400', 'meters', '10.00', '20.00', '400 meters', '8000.00', '\\Siamese', 'installed'),
('OPR001', 'v2PROD004', 'Camera', 'Bullet IP', 'Hikvision', 'Octagon', 'S09FD8G7S986FSD986H', 'S-D09F7HS0DHSD89FH7D89H7', '10/6/2017', '1', 'unit', '2599.25', '3500.00', '1 unit', '3500.00', '\\2MP\\Infrared', 'installed'),
('OPR001', 'v2PROD006', 'Hard Drive', '', 'SeaGate', 'Electronics', '0D9S8FH79D8F8D9F', 'SDF908H7SDF9S8FDH9SD8H7', '10/7/2017', '1', 'unit', '4599.00', '5000.00', '1 unit', '5000.00', '\\10TB\\64mb Cache\\SATA', 'installed'),
('OPR001', 'v2PROD007', 'HDMI Cable', '5 meters', '', 'CD-R King', NULL, '', '10/6/2017', '2', 'pcs', '999.25', '1900.00', '2 pcs', '3800.00', '\\5 meters\\High-definition multimedia interface', 'installed'),
('OPR001', 'v2PROD009', 'VGA Cable', 'VGA', '', 'CD-R King', NULL, '', '10/6/2017', '5', 'pcs', '799.25', '1000.00', '5 pcs', '5000.00', '\\5 meters', 'installed'),
('OPR001', 'v2PROD002', 'Camera', 'Bullet Analogue', 'Dahua', 'Electronics', 'S90DFGH7SD8FHDF78', 'SD98GYSF908DHD8H8', '10/7/2017', '1', 'unit', '1000.00', '1200.00', '1 unit', '1200.00', '\\2MP\\720p', 'installed'),
('OPR001', 'v2PROD003', 'Camera', 'Bullet Analogue', 'Dahua', 'Electronics', 'SD98FHS7HF6SD7FH6', 'SDF90HS7DF89SH78FHD7', '10/6/2017', '1', 'unit', '2999.52', '3500.00', '1 unit', '3500.00', '\\1MP', 'installed'),
('OPR002', 'v2PROD005', 'Camera', 'Dome Analogue', 'Dahua', 'Electronics', 'D09F8HSDH6DSHF6F', 'D0F-HS97FHD0DSFH7H-SD', '10/8/2017', '1', 'unit', '2499.25', '2499.25', '1 unit', '2499.25', '\\1080p\\2MP\\Infrared', 'installed'),
('OPR002', 'v2PROD008', 'Camera', 'Bullet IP', 'Hikvision', 'Octagon', 'SDF-09HS89HFD8HSF9H9', '9DF8H7S0D8F6H9SDF8D8F', '10/9/2017', '1', 'unit', '2599.00', '2599.00', '1 unit', '2599.00', '\\1080p\\4MP\\720p\\Infrared', 'installed'),
('OPR002', 'v2PROD010', 'Camera', 'Bullet IP', 'Dahua', 'Electronics', '89DSFH6S8DH8DSHS', '8S9DG6986DH78FDH68FD67', '10/11/2017', '1', 'unit', '9999.00', '9999.00', '1 unit', '9999.00', '\\4MP\\720p\\Infrared', 'installed'),
('OPR002', 'v2PROD011', 'Camera', 'Bullet IP', 'Hikvision', 'Electronics', '098DSF6H98D6H8DS9F68', 'DS0FH7SDH7DH7DSF9HSF8', '10/8/2017', '1', 'unit', '2999.75', '2999.75', '1 unit', '2999.75', '\\1080p\\4MP\\Infrared', 'installed'),
('OPR002', 'v2PROD012', 'Camera', 'Bullet Analogue', 'Dahua', 'Electronics', 'SF09G7DS9GHFD89', 'SF9H7S9D-0H89987', '11/7/2017', '1', 'unit', '3000.00', '3000.00', '1 unit', '3000.00', '\\2MP\\720p\\Infrared', 'installed'),
('OPR003', 'v2PROD013', 'Cable', 'Coaxial', '', 'Electronics', NULL, '', '10/8/2017', '100', 'meters', '15.00', '15.00', '100 meters', '1500.00', '\\Siamese', 'installed'),
('OPR003', 'v2PROD014', 'HDMI Cable', '5 meters', '', 'Electronics', NULL, '', '10/8/2017', '3', 'pcs', '899.75', '899.75', '3 pcs', '2699.25', '\\5 meters\\High-definition multimedia interface', 'installed'),
('OPR003', 'v2PROD015', 'Switch', 'Power Switch', '', 'CD-R King', NULL, '', '10/8/2017', '1', 'unit', '6969.69', '6969.69', '1 unit', '6969.69', '', 'installed');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_personel`
--

CREATE TABLE `tbl_personel` (
  `fullname` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_personel`
--

INSERT INTO `tbl_personel` (`fullname`) VALUES
('Ryan Empleo Esper'),
('Jubeth Ligtas Alag'),
('Ricky'),
('Rhemon'),
('Jazheel'),
('Ian');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_product_brand`
--

CREATE TABLE `tbl_product_brand` (
  `product_name` varchar(500) NOT NULL,
  `brand` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_product_brand`
--

INSERT INTO `tbl_product_brand` (`product_name`, `brand`) VALUES
('Hard Drive', 'Hitachi'),
('Camera', 'Dahua'),
('Video Recorder', 'Dahua'),
('Hard Drive', 'SanDisk'),
('Video Recorder', 'HikVision'),
('Camera', 'Hikvision'),
('Hard Drive', 'Sea Gate'),
('Hard Drive', 'SeaGate'),
('PTZ', 'Dahua');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_product_name`
--

CREATE TABLE `tbl_product_name` (
  `name` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_product_name`
--

INSERT INTO `tbl_product_name` (`name`) VALUES
('Hard Drive'),
('Camera'),
('Video Recorder'),
('HDMI Cable'),
('VGA Cable'),
('Power Supply'),
('PTZ'),
('Switch'),
('GigaBit'),
('Cable');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_product_others`
--

CREATE TABLE `tbl_product_others` (
  `others` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_product_others`
--

INSERT INTO `tbl_product_others` (`others`) VALUES
('BNC and DC Connector'),
('Switch'),
('HMDI Cable'),
('wla lang'),
('haaah');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_product_quantity_unit`
--

CREATE TABLE `tbl_product_quantity_unit` (
  `product_name` varchar(500) NOT NULL,
  `quantity_unit` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_product_quantity_unit`
--

INSERT INTO `tbl_product_quantity_unit` (`product_name`, `quantity_unit`) VALUES
('Camera', 'unit'),
('Hard Drive', 'unit'),
('Video Recorder', 'unit'),
('HDMI Cable', 'pcs'),
('VGA Cable', 'unit'),
('VGA Cable', 'pcs'),
('Power Supply', 'unit'),
('PTZ', 'unit'),
('Switch', 'unit'),
('GigaBit', 'unit'),
('', 'unit'),
('Cable', 'meters');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_product_specs`
--

CREATE TABLE `tbl_product_specs` (
  `product_name` varchar(500) NOT NULL,
  `specification` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_product_specs`
--

INSERT INTO `tbl_product_specs` (`product_name`, `specification`) VALUES
('Hard Drive', '10TB'),
('Hard Drive', '64mb Cache'),
('Hard Drive', '4TB'),
('HDMI Cable', 'High-definition multimedia interface'),
('Video Recorder', '16 Channel'),
('Video Recorder', '8 Channel'),
('HDMI Cable', '5 meters'),
('HDMI Cable', '3 meters'),
('Hard Drive', '2TB'),
('VGA Cable', '5 meters'),
('VGA Cable', '3 meters'),
('PTZ', '40x Optical Zoom'),
('PTZ', '5MP'),
('PTZ', 'Pan Tilt Zoom'),
('Camera', '2MP'),
('Camera', '720p'),
('Camera', 'Infrared'),
('Camera', '1080p'),
('Camera', '1MP'),
('Camera', '4MP'),
('', 'Infrared'),
('Power Supply', '10A'),
('Power Supply', '12V'),
('Power Supply', 'Centralize Power Supply'),
('Hard Drive', 'SATA'),
('Cable', 'Siamese');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_product_supplier`
--

CREATE TABLE `tbl_product_supplier` (
  `product_name` varchar(500) NOT NULL,
  `supplier` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_product_supplier`
--

INSERT INTO `tbl_product_supplier` (`product_name`, `supplier`) VALUES
('Hard Drive', 'Electronics'),
('Camera', 'Electronics'),
('Video Recorder', 'CD-R King'),
('Video Recorder', 'Electronics'),
('Camera', 'Octagon'),
('HDMI Cable', 'Electronics'),
('HDMI Cable', 'CD-R King'),
('VGA Cable', 'CD-R King'),
('Power Supply', 'CD-R King'),
('PTZ', 'Electronics'),
('Switch', 'CD-R King'),
('GigaBit', 'Electronics'),
('Cable', 'Electronics');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_product_type`
--

CREATE TABLE `tbl_product_type` (
  `product_name` varchar(500) NOT NULL,
  `type` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_product_type`
--

INSERT INTO `tbl_product_type` (`product_name`, `type`) VALUES
('Camera', 'Bullet IP'),
('Video Recorder', 'DVR'),
('Video Recorder', 'NVR'),
('Camera', 'Dome Analogue'),
('HDMI Cable', 'HDMI'),
('Camera', 'Bullet Analogue'),
('VGA Cable', 'VGA'),
('PTZ', 'Bullet IP'),
('Switch', 'Power Switch'),
('HDMI Cable', '5 meters'),
('HDMI Cable', '3 meters'),
('Cable', 'Coaxial');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stocks`
--

CREATE TABLE `tbl_stocks` (
  `product_id` varchar(500) NOT NULL,
  `product` varchar(500) NOT NULL,
  `type` varchar(500) NOT NULL,
  `brand` varchar(500) NOT NULL,
  `supplier` varchar(500) NOT NULL,
  `serial` varchar(500) DEFAULT NULL,
  `model` varchar(500) NOT NULL,
  `arrival_date` varchar(500) NOT NULL,
  `quantity` varchar(500) NOT NULL,
  `unit` varchar(500) NOT NULL,
  `unit_price` decimal(65,2) NOT NULL,
  `quantity_unit` varchar(500) NOT NULL,
  `totalprice` decimal(65,2) NOT NULL,
  `specification` varchar(5000) NOT NULL,
  `status` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_stocks`
--

INSERT INTO `tbl_stocks` (`product_id`, `product`, `type`, `brand`, `supplier`, `serial`, `model`, `arrival_date`, `quantity`, `unit`, `unit_price`, `quantity_unit`, `totalprice`, `specification`, `status`) VALUES
('PROD006', 'HDMI Cable', '5 meters', '', 'Electronics', NULL, '', '10/8/2017', '5', 'pcs', '899.75', '5 pcs', '4498.75', '\\5 meters\\High-definition multimedia interface', 'available'),
('PROD002', 'Cable', 'Coaxial', '', 'Electronics', NULL, '', '10/8/2017', '200', 'meters', '15.00', '200 meters', '3000.00', '\\Siamese', 'available'),
('PROD009', 'HDMI Cable', '5 meters', '', 'Electronics', NULL, '', '10/8/2017', '7', 'pcs', '899.75', '7 pcs', '6298.25', '\\5 meters\\High-definition multimedia interface', 'available');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transactions`
--

CREATE TABLE `tbl_transactions` (
  `transaction_id` varchar(500) NOT NULL,
  `date_sold` varchar(500) NOT NULL,
  `client` varchar(500) NOT NULL,
  `address` varchar(500) NOT NULL,
  `contact_number` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_transactions`
--

INSERT INTO `tbl_transactions` (`transaction_id`, `date_sold`, `client`, `address`, `contact_number`) VALUES
('TRN001', '10/8/2017', 'Ryan E. Esper', 'Calibunan', '09096352523'),
('TRN002', '10/9/2017', 'Rodrigo Roa Duterte', 'Davao City', '098479847698');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transaction_item_sold`
--

CREATE TABLE `tbl_transaction_item_sold` (
  `transaction_id` varchar(500) NOT NULL,
  `product_id` varchar(500) NOT NULL,
  `product` varchar(500) NOT NULL,
  `type` varchar(500) NOT NULL,
  `brand` varchar(500) NOT NULL,
  `supplier` varchar(500) NOT NULL,
  `serial` varchar(500) DEFAULT NULL,
  `model` varchar(500) NOT NULL,
  `arrival_date` varchar(500) NOT NULL,
  `quantity` varchar(500) NOT NULL,
  `unit` varchar(500) NOT NULL,
  `unit_price` decimal(65,2) NOT NULL,
  `selling_price` decimal(65,2) NOT NULL,
  `quantity_unit` varchar(500) NOT NULL,
  `total_price` decimal(65,2) NOT NULL,
  `specification` varchar(5000) NOT NULL,
  `status` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_transaction_item_sold`
--

INSERT INTO `tbl_transaction_item_sold` (`transaction_id`, `product_id`, `product`, `type`, `brand`, `supplier`, `serial`, `model`, `arrival_date`, `quantity`, `unit`, `unit_price`, `selling_price`, `quantity_unit`, `total_price`, `specification`, `status`) VALUES
('TRN001', 'v3PROD001', 'HDMI Cable', '5 meters', '', 'Electronics', NULL, '', '10/8/2017', '1', 'pcs', '999.25', '1000.00', '1 pcs', '1000.00', '\\5 meters\\High-definition multimedia interface', 'sold'),
('TRN001', 'v3PROD002', 'PTZ', 'Bullet IP', 'Dahua', 'Electronics', '98DF6H87D6HSD78FH6S78', 'S987FH7SDH6S8D9HF678FD', '10/8/2017', '1', 'unit', '21250.25', '22000.00', '1 unit', '22000.00', '\\40x Optical Zoom\\5MP\\Pan Tilt Zoom', 'sold'),
('TRN002', 'v3PROD003', 'Cable', 'Coaxial', '', 'Electronics', NULL, '', '10/8/2017', '30', 'meters', '15.00', '20.00', '30 meters', '600.00', '\\Siamese', 'sold'),
('TRN002', 'v3PROD004', 'HDMI Cable', '5 meters', '', 'Electronics', NULL, '', '10/8/2017', '1', 'pcs', '899.75', '1000.00', '1 pcs', '1000.00', '\\5 meters\\High-definition multimedia interface', 'sold');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transaction_item_total`
--

CREATE TABLE `tbl_transaction_item_total` (
  `transaction_id` varchar(500) NOT NULL,
  `qty` varchar(500) NOT NULL,
  `quantity` varchar(500) NOT NULL,
  `items` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_transaction_item_total`
--

INSERT INTO `tbl_transaction_item_total` (`transaction_id`, `qty`, `quantity`, `items`) VALUES
('TRN001', '1', '1 unit', 'PTZ (Bullet IP)'),
('TRN001', '1', '1 pcs', 'HDMI Cable (5 meters)'),
('TRN002', '1', '1 pcs', 'HDMI Cable (5 meters)'),
('TRN002', '30', '30 meters', 'Cable (Coaxial)');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
