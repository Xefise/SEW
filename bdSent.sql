-- phpMyAdmin SQL Dump
-- version 4.6.6deb5
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Май 01 2020 г., 09:34
-- Версия сервера: 5.7.29-0ubuntu0.18.04.1
-- Версия PHP: 7.2.24-0ubuntu0.18.04.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `SentDiscordBot`
--

-- --------------------------------------------------------

--
-- Структура таблицы `guilds`
--

CREATE TABLE `guilds` (
  `id` int(10) UNSIGNED NOT NULL,
  `guildID` bigint(20) UNSIGNED NOT NULL,
  `bitrate` smallint(3) UNSIGNED NOT NULL DEFAULT '96',
  `logChannel` bigint(20) UNSIGNED DEFAULT NULL COMMENT 'id',
  `whiteChannels` varchar(255) NOT NULL DEFAULT '[]',
  `voiceChannelsCategory` bigint(20) DEFAULT NULL COMMENT 'id',
  `prefix` varchar(5) NOT NULL DEFAULT '!-',
  `roleMessage` bigint(20) UNSIGNED DEFAULT NULL,
  `roleChannel` bigint(20) UNSIGNED DEFAULT NULL,
  `gameRoles` varchar(255) NOT NULL DEFAULT '[]'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `guilds`
--
ALTER TABLE `guilds`
  ADD PRIMARY KEY (`id`),
  ADD KEY `guildID` (`guildID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `guilds`
--
ALTER TABLE `guilds`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=193;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
