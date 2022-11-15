-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.25-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for endeavour1
DROP DATABASE IF EXISTS `endeavour1`;
CREATE DATABASE IF NOT EXISTS `endeavour1` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `endeavour1`;

-- Dumping structure for table endeavour1.creditcard
DROP TABLE IF EXISTS `creditcard`;
CREATE TABLE IF NOT EXISTS `creditcard` (
  `id` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `type` enum('Visa','MasterCard','AmericanExpress','DiscoverCard') NOT NULL,
  `number` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `expirationDate` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table endeavour1.user
DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `userId` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `address` varchar(50) DEFAULT NULL,
  `checked` tinyint(4) NOT NULL DEFAULT 0,
  `description` text DEFAULT NULL,
  `interest` varchar(50) DEFAULT NULL,
  `date_of_birth` datetime DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `account` varchar(50) DEFAULT NULL,
  `creditcard` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
