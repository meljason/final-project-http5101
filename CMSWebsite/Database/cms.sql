-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Dec 04, 2019 at 04:46 AM
-- Server version: 5.7.26
-- PHP Version: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cms`
--

-- --------------------------------------------------------

--
-- Table structure for table `pages`
--

DROP TABLE IF EXISTS `pages`;
CREATE TABLE IF NOT EXISTS `pages` (
  `pageid` tinyint(4) NOT NULL AUTO_INCREMENT,
  `pagetitle` varchar(255) COLLATE latin1_bin NOT NULL,
  `pagebody` text COLLATE latin1_bin NOT NULL,
  `pageimage` blob NOT NULL,
  `dateupload` date NOT NULL,
  PRIMARY KEY (`pageid`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

--
-- Dumping data for table `pages`
--

INSERT INTO `pages` (`pageid`, `pagetitle`, `pagebody`, `pageimage`, `dateupload`) VALUES
(1, 'Ledner and Sons', 'id ligula suspendisse ornare consequat lectus in est risus auctor sed tristique in tempus sit', '', '2018-03-02'),
(2, 'Batz-Hills', 'in leo maecenas pulvinar lobortis est phasellus sit amet erat nulla', '', '2019-06-19'),
(3, 'Ryan-Grady', 'luctus et ultrices posuere cubilia curae duis faucibus accumsan odio curabitur convallis duis consequat dui nec nisi volutpat eleifend donec', '', '2019-08-23'),
(4, 'Mills LLC', 'rutrum at lorem integer tincidunt ante vel ipsum praesent blandit lacinia erat vestibulum sed magna at nunc commodo placerat praesent', '', '2018-03-11'),
(5, 'Weissnat, Willms and O\'Kon', 'ac enim in tempor turpis nec euismod scelerisque quam turpis adipiscing lorem vitae mattis', '', '2016-12-01'),
(6, 'Ritchie, Koelpin and Mayert', 'non mauris morbi non lectus aliquam sit amet diam in', '', '2018-06-30'),
(7, 'Davis and Sons', 'faucibus orci luctus et ultrices posuere cubilia curae duis faucibus', '', '2019-07-19'),
(8, 'Jacobs, Runte and Rowe', 'quis lectus suspendisse potenti in eleifend quam a odio in hac habitasse platea', '', '2018-02-24'),
(9, 'Thiel-Yundt', 'vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor', '', '2016-02-07'),
(10, 'Upton-Kulas', 'consequat lectus in est risus auctor sed tristique in tempus', '', '2016-01-03'),
(11, 'Oberbrunner LLC', 'interdum venenatis turpis enim blandit mi in porttitor pede justo eu massa donec dapibus duis at', '', '2017-03-01'),
(12, 'Okuneva, Cremin and Skiles', 'vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae duis faucibus', '', '2017-07-03'),
(13, 'Mosciski Group', 'risus praesent lectus vestibulum quam sapien varius ut blandit non', '', '2019-03-14'),
(14, 'Funk Inc', 'duis at velit eu est congue elementum in hac habitasse platea dictumst morbi vestibulum velit id pretium', '', '2018-07-01'),
(15, 'Stokes LLC', 'fermentum justo nec condimentum neque sapien placerat ante nulla justo aliquam quis turpis eget elit sodales scelerisque mauris', '', '2018-09-11'),
(16, 'Reinger-Waters', 'lorem ipsum dolor sit amet consectetuer adipiscing elit proin risus praesent lectus vestibulum', '', '2018-03-13'),
(17, 'Dare, Willms and Predovic', 'at turpis donec posuere metus vitae ipsum aliquam non mauris morbi non lectus', '', '2017-06-06'),
(18, 'Moore Inc', 'nisl nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit mi', '', '2017-06-27'),
(19, 'Brown, Marquardt and Lehner', 'sem fusce consequat nulla nisl nunc nisl duis bibendum felis sed interdum', '', '2016-08-04');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
