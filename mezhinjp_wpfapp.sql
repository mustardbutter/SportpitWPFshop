-- phpMyAdmin SQL Dump
-- version 4.9.7
-- https://www.phpmyadmin.net/
--
-- Хост: localhost
-- Время создания: Окт 27 2023 г., 10:11
-- Версия сервера: 5.7.21-20-beget-5.7.21-20-1-log
-- Версия PHP: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `mezhinjp_wpfapp`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Items_list`
--
-- Создание: Окт 26 2023 г., 17:51
--

DROP TABLE IF EXISTS `Items_list`;
CREATE TABLE `Items_list` (
  `Article_Number` varchar(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Price` int(11) NOT NULL,
  `Creator` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Count` int(11) NOT NULL,
  `Description` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `Role`
--
-- Создание: Окт 26 2023 г., 16:52
--

DROP TABLE IF EXISTS `Role`;
CREATE TABLE `Role` (
  `Id` int(11) NOT NULL,
  `Role` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `User`
--
-- Создание: Окт 26 2023 г., 17:16
--

DROP TABLE IF EXISTS `User`;
CREATE TABLE `User` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Login` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `IdRole` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `Zakazi2`
--
-- Создание: Окт 26 2023 г., 17:37
--

DROP TABLE IF EXISTS `Zakazi2`;
CREATE TABLE `Zakazi2` (
  `Nomer_Zakaza` int(11) NOT NULL,
  `Sostav_Zakaza` varchar(50) NOT NULL,
  `Date_Zakaza` date NOT NULL,
  `Date_Dostavka` date NOT NULL,
  `pynkt_vidachi1` int(11) NOT NULL,
  `Full_name` varchar(50) NOT NULL,
  `Kod_polychenia` int(11) NOT NULL,
  `Status_zakaza` varchar(50) NOT NULL,
  `City` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Zakazii2))))';

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Items_list`
--
ALTER TABLE `Items_list`
  ADD PRIMARY KEY (`Article_Number`);

--
-- Индексы таблицы `Role`
--
ALTER TABLE `Role`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `User`
--
ALTER TABLE `User`
  ADD PRIMARY KEY (`Name`);

--
-- Индексы таблицы `Zakazi2`
--
ALTER TABLE `Zakazi2`
  ADD PRIMARY KEY (`Nomer_Zakaza`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
