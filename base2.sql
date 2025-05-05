-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 06 2025 г., 01:24
-- Версия сервера: 8.0.30
-- Версия PHP: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `base2`
--

DELIMITER $$
--
-- Процедуры
--
CREATE DEFINER=`root`@`%` PROCEDURE `GetChanges` (IN `id` INT)   BEGIN
    SELECT
        prod.name,
        prod.priceMin,
        partprod.countProduct,
        partprod.dateSell  -- Make sure to include this column
    FROM
        Products prod
    JOIN
        Partner_Products partprod ON partprod.product = prod.id
    WHERE
        partprod.partner = id;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `Materials`
--

CREATE TABLE `Materials` (
  `id` bigint NOT NULL,
  `typeMaterial` text,
  `defectRate` float DEFAULT NULL,
  `name` text,
  `supplier` bigint DEFAULT NULL,
  `countPackage` int DEFAULT NULL,
  `description` text,
  `image` longblob,
  `price` float DEFAULT NULL,
  `countInStorage` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Materials`
--

INSERT INTO `Materials` (`id`, `typeMaterial`, `defectRate`, `name`, `supplier`, `countPackage`, `description`, `image`, `price`, `countInStorage`) VALUES
(1, 'Тип материала 1', 0.001, 'Материал 1', NULL, NULL, NULL, NULL, NULL, NULL),
(2, 'Тип материала 2', 0.0095, 'Материал 2', NULL, NULL, NULL, NULL, NULL, NULL),
(3, 'Тип материала 3', 0.0028, 'Материал 3', NULL, NULL, NULL, NULL, NULL, NULL),
(4, 'Тип материала 4', 0.0055, 'Материал 4', NULL, NULL, NULL, NULL, NULL, NULL),
(5, 'Тип материала 5', 0.0034, 'Материал 5', NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `Partners`
--

CREATE TABLE `Partners` (
  `id` bigint NOT NULL,
  `typePartner` bigint DEFAULT NULL,
  `nameCompany` text,
  `address` varchar(255) DEFAULT NULL,
  `inn` bigint DEFAULT NULL,
  `fioDirector` varchar(255) DEFAULT NULL,
  `telephone` varchar(40) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `rating` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Partners`
--

INSERT INTO `Partners` (`id`, `typePartner`, `nameCompany`, `address`, `inn`, `fioDirector`, `telephone`, `email`, `rating`) VALUES
(1, 1, 'asd', 'asdasd', 123, 'Asd Assd Asssdff', '889898989898', 'asd@asd.ru', 2),
(2, 1, 'База Строитель', '652050, Кемеровская область, город Юрга, ул. Лесная, 15', 2222455179, 'Иванова Александра Ивановна', '493 123 45 67', 'aleksandraivanova@ml.ru', 7),
(3, 2, 'Паркет 29', '164500, Архангельская область, город Северодвинск, ул. Строителей, 18', 3333888520, 'Петров Василий Петрович', '987 123 56 78', 'vppetrov@vl.ru', 7),
(4, 3, 'Стройсервис', '188910, Ленинградская область, город Приморск, ул. Парковая, 21', 4440391035, 'Соловьев Андрей Николаевич', '812 223 32 00', 'ansolovev@st.ru', 7),
(5, 4, 'Ремонт и отделка', '143960, Московская область, город Реутов, ул. Свободы, 51', 1111520857, 'Воробьева Екатерина Валерьевна', '444 222 33 11', 'ekaterina.vorobeva@ml.ru', 5),
(6, 5, 'МонтажПро', '309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122', 5552431140, 'Степанов Степан Сергеевич', '912 888 33 33', 'stepanov@stepan.ru', 10),
(17, 1, 'Крутой строитель', 'Луначарского 24', 1236547899, 'Иванова Александра Ивановна', '89994563217', 'artem@mail.ru', 10),
(18, 5, 'Zxc', 'Zxc', 1234567891, 'Zxc Zxc Zxc', '86666666666', 'zxc@zxc.ru', 4),
(19, 1, 'Stroim', 'лвы', 1234567890, 'Липи Кри Алк', '89504609974', 'dsds2@gmail.com', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Partner_Products`
--

CREATE TABLE `Partner_Products` (
  `id` bigint NOT NULL,
  `product` bigint DEFAULT NULL,
  `partner` bigint DEFAULT NULL,
  `countProduct` int DEFAULT NULL,
  `dateSell` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Partner_Products`
--

INSERT INTO `Partner_Products` (`id`, `product`, `partner`, `countProduct`, `dateSell`) VALUES
(1, 2, 2, 15500, '2023-03-20'),
(2, 1, 1, 59350, '2018-12-20'),
(3, 3, 3, 374000, '2024-06-07'),
(4, 1, 1, 374000, '2024-06-06');

-- --------------------------------------------------------

--
-- Структура таблицы `Products`
--

CREATE TABLE `Products` (
  `id` bigint NOT NULL,
  `typeProduct` bigint DEFAULT NULL,
  `articleNumber` char(10) DEFAULT NULL,
  `name` text,
  `priceMin` float DEFAULT NULL,
  `dateChanges` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Products`
--

INSERT INTO `Products` (`id`, `typeProduct`, `articleNumber`, `name`, `priceMin`, `dateChanges`) VALUES
(1, 1, '8758385', 'Паркетная доска Ясень темный однополосная 14 мм', 4456.9, '2024-12-12'),
(2, 1, '8858958', 'Инженерная доска Дуб Французская елка однополосная 12 мм', 7330.99, '2024-12-12'),
(3, 2, '7750282', 'Ламинат Дуб дымчато-белый 33 класс 12 мм', 1799.33, '2024-12-12'),
(4, 2, '7028748', 'Ламинат Дуб серый 32 класс 8 мм с фаской', 3890.41, '2024-12-12'),
(5, 3, '5012543', 'Пробковое напольное клеевое покрытие 32 класс 4 мм', 5450.59, '2024-12-12');

-- --------------------------------------------------------

--
-- Структура таблицы `Required_Material`
--

CREATE TABLE `Required_Material` (
  `id` bigint NOT NULL,
  `product` bigint DEFAULT NULL,
  `material` bigint DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Required_Material`
--

INSERT INTO `Required_Material` (`id`, `product`, `material`) VALUES
(1, 2, 3),
(2, 3, 2),
(3, 1, 1),
(4, 1, 5),
(5, 4, 5),
(6, 1, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Suppliers`
--

CREATE TABLE `Suppliers` (
  `id` bigint NOT NULL,
  `typeSupplier` varchar(100) DEFAULT NULL,
  `name` text,
  `inn` bigint DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Suppliers`
--

INSERT INTO `Suppliers` (`id`, `typeSupplier`, `name`, `inn`) VALUES
(1, 'ЗАО', 'База Строитель', 2222455179),
(2, 'ООО', 'Паркет 29', 3333888520),
(3, 'ПАО', 'Стройсервис', 4440391035),
(4, 'ОАО', 'Ремонт и отделка', 1111520857),
(5, 'ЗАО', 'МонтажПро', 5552431140);

-- --------------------------------------------------------

--
-- Структура таблицы `Type_Partner`
--

CREATE TABLE `Type_Partner` (
  `id` bigint NOT NULL,
  `name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Type_Partner`
--

INSERT INTO `Type_Partner` (`id`, `name`) VALUES
(1, 'ЗАО'),
(2, 'ООО'),
(3, 'ПАО'),
(4, 'ОАО'),
(5, 'ЗАО');

-- --------------------------------------------------------

--
-- Структура таблицы `Type_Product`
--

CREATE TABLE `Type_Product` (
  `id` bigint NOT NULL,
  `name` text,
  `coefficient` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Type_Product`
--

INSERT INTO `Type_Product` (`id`, `name`, `coefficient`) VALUES
(1, 'Ламинат', 2.35),
(2, 'Массивная доска', 5.15),
(3, 'Паркетная доска', 4.34),
(4, 'Пробковое покрытие', 1.5);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Materials`
--
ALTER TABLE `Materials`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Material_type_Suppliers` (`supplier`);

--
-- Индексы таблицы `Partners`
--
ALTER TABLE `Partners`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Partners_Type_Partner` (`typePartner`);

--
-- Индексы таблицы `Partner_Products`
--
ALTER TABLE `Partner_Products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Partner_Products_Partners` (`partner`),
  ADD KEY `FK_Partner_Products_Products` (`product`);

--
-- Индексы таблицы `Products`
--
ALTER TABLE `Products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Products_Type_Product` (`typeProduct`);

--
-- Индексы таблицы `Required_Material`
--
ALTER TABLE `Required_Material`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Required_Material_Materials` (`material`),
  ADD KEY `FK_Required_Material_Products` (`product`);

--
-- Индексы таблицы `Suppliers`
--
ALTER TABLE `Suppliers`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Type_Partner`
--
ALTER TABLE `Type_Partner`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Type_Product`
--
ALTER TABLE `Type_Product`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Materials`
--
ALTER TABLE `Materials`
  MODIFY `id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Partners`
--
ALTER TABLE `Partners`
  MODIFY `id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT для таблицы `Partner_Products`
--
ALTER TABLE `Partner_Products`
  MODIFY `id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `Products`
--
ALTER TABLE `Products`
  MODIFY `id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `Required_Material`
--
ALTER TABLE `Required_Material`
  MODIFY `id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `Suppliers`
--
ALTER TABLE `Suppliers`
  MODIFY `id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Type_Partner`
--
ALTER TABLE `Type_Partner`
  MODIFY `id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Type_Product`
--
ALTER TABLE `Type_Product`
  MODIFY `id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Materials`
--
ALTER TABLE `Materials`
  ADD CONSTRAINT `FK_Material_type_Suppliers` FOREIGN KEY (`supplier`) REFERENCES `Suppliers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Partners`
--
ALTER TABLE `Partners`
  ADD CONSTRAINT `FK_Partners_Type_Partner` FOREIGN KEY (`typePartner`) REFERENCES `Type_Partner` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Partner_Products`
--
ALTER TABLE `Partner_Products`
  ADD CONSTRAINT `FK_Partner_Products_Partners` FOREIGN KEY (`partner`) REFERENCES `Partners` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_Partner_Products_Products` FOREIGN KEY (`product`) REFERENCES `Products` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Products`
--
ALTER TABLE `Products`
  ADD CONSTRAINT `FK_Products_Type_Product` FOREIGN KEY (`typeProduct`) REFERENCES `Type_Product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Required_Material`
--
ALTER TABLE `Required_Material`
  ADD CONSTRAINT `FK_Required_Material_Materials` FOREIGN KEY (`material`) REFERENCES `Materials` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_Required_Material_Products` FOREIGN KEY (`product`) REFERENCES `Products` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
