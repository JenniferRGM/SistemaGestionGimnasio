-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.30 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para sistemagestiongimnasio
CREATE DATABASE IF NOT EXISTS `sistemagestiongimnasio` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `sistemagestiongimnasio`;

-- Volcando estructura para tabla sistemagestiongimnasio.actividades
CREATE TABLE IF NOT EXISTS `actividades` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Fecha` date NOT NULL,
  `Horario` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `Entrenador` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Cupo` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.actividades: ~5 rows (aproximadamente)
INSERT INTO `actividades` (`id`, `Nombre`, `Fecha`, `Horario`, `Entrenador`, `Cupo`) VALUES
	(1, 'Ejercicios funcionales', '2024-11-27', '5:00 - 6:00', 'Andrea Mora Salas', 25),
	(2, 'Spinning', '2024-11-27', '6:00 - 7:00', 'Alejandro Solano Jimenez', 25),
	(3, 'Yoga Matutino', '2024-11-27', '7:00 - 8:00', 'Veronica Solis Castro', 25),
	(4, 'CrossFit', '2024-11-27', '8:00 - 9:00', 'Diego Fernandez Rojas', 25),
	(5, 'Zumba', '2024-11-27', '9:00 - 10:00', 'Maria Jose Quesada Vargas', 25);

-- Volcando estructura para tabla sistemagestiongimnasio.clases
CREATE TABLE IF NOT EXISTS `clases` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `entrenador_id` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.clases: ~4 rows (aproximadamente)
INSERT INTO `clases` (`id`, `nombre`, `entrenador_id`) VALUES
	(1, 'Ejercicios funcionales', 5),
	(2, 'Spinning', 2),
	(3, 'Yoga Matutino', 3),
	(4, 'Yoga Fino', 3);

-- Volcando estructura para tabla sistemagestiongimnasio.clases_espacios
CREATE TABLE IF NOT EXISTS `clases_espacios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `clase_id` int DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `cupos` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.clases_espacios: ~4 rows (aproximadamente)
INSERT INTO `clases_espacios` (`id`, `clase_id`, `fecha`, `cupos`) VALUES
	(1, 1, '2024-01-01 00:00:00', 3),
	(2, 2, '2008-01-01 05:00:00', 4),
	(3, 3, '2024-01-01 11:00:00', 18),
	(4, 4, '2024-05-01 00:00:00', 36);

-- Volcando estructura para tabla sistemagestiongimnasio.clases_reservas
CREATE TABLE IF NOT EXISTS `clases_reservas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `clase_espacio_id` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `cliente_id` text COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.clases_reservas: ~12 rows (aproximadamente)
INSERT INTO `clases_reservas` (`id`, `clase_espacio_id`, `cliente_id`) VALUES
	(2, '4', '1'),
	(3, '4', '1'),
	(4, '4', '1'),
	(5, '4', '1'),
	(6, '4', '1'),
	(7, '4', '1'),
	(8, '4', '1'),
	(9, '4', '2'),
	(10, '2', '2'),
	(11, '1', '2'),
	(12, '3', '2'),
	(13, '4', '2');

-- Volcando estructura para tabla sistemagestiongimnasio.egresos
CREATE TABLE IF NOT EXISTS `egresos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `monto` decimal(20,6) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.egresos: ~50 rows (aproximadamente)
INSERT INTO `egresos` (`id`, `descripcion`, `monto`, `fecha`) VALUES
	(1, 'Pago de salarios', 1500.000000, '2024-01-01'),
	(2, 'Compra de materiales', 300.000000, '2024-01-02'),
	(3, 'Pago de alquiler', 1200.000000, '2024-01-03'),
	(4, 'Gastos de publicidad', 450.000000, '2024-01-05'),
	(5, 'Compra de equipo', 800.000000, '2024-01-06'),
	(6, 'Pago de servicios', 250.000000, '2024-01-07'),
	(7, 'Gastos operativos', 300.000000, '2024-01-10'),
	(8, 'Pago de impuestos', 600.000000, '2024-01-12'),
	(9, 'Gastos de publicidad', 500.000000, '2024-01-15'),
	(10, 'Pago de proveedores', 700.000000, '2024-01-16'),
	(11, 'Pago de salarios', 1550.000000, '2024-02-01'),
	(12, 'Compra de materiales', 320.000000, '2024-02-02'),
	(13, 'Pago de alquiler', 1250.000000, '2024-02-04'),
	(14, 'Gastos de publicidad', 460.000000, '2024-02-06'),
	(15, 'Compra de equipo', 850.000000, '2024-02-07'),
	(16, 'Pago de servicios', 270.000000, '2024-02-10'),
	(17, 'Gastos operativos', 310.000000, '2024-02-12'),
	(18, 'Pago de impuestos', 620.000000, '2024-02-14'),
	(19, 'Gastos de publicidad', 510.000000, '2024-02-17'),
	(20, 'Pago de proveedores', 720.000000, '2024-02-20'),
	(21, 'Pago de salarios', 1600.000000, '2024-03-01'),
	(22, 'Compra de materiales', 330.000000, '2024-03-02'),
	(23, 'Pago de alquiler', 1300.000000, '2024-03-05'),
	(24, 'Gastos de publicidad', 470.000000, '2024-03-08'),
	(25, 'Compra de equipo', 870.000000, '2024-03-09'),
	(26, 'Pago de servicios', 280.000000, '2024-03-12'),
	(27, 'Gastos operativos', 320.000000, '2024-03-14'),
	(28, 'Pago de impuestos', 640.000000, '2024-03-16'),
	(29, 'Gastos de publicidad', 520.000000, '2024-03-20'),
	(30, 'Pago de proveedores', 740.000000, '2024-03-21'),
	(31, 'Pago de salarios', 1650.000000, '2024-04-01'),
	(32, 'Compra de materiales', 340.000000, '2024-04-02'),
	(33, 'Pago de alquiler', 1350.000000, '2024-04-04'),
	(34, 'Gastos de publicidad', 480.000000, '2024-04-06'),
	(35, 'Compra de equipo', 890.000000, '2024-04-08'),
	(36, 'Pago de servicios', 290.000000, '2024-04-10'),
	(37, 'Gastos operativos', 330.000000, '2024-04-12'),
	(38, 'Pago de impuestos', 660.000000, '2024-04-14'),
	(39, 'Gastos de publicidad', 530.000000, '2024-04-17'),
	(40, 'Pago de proveedores', 760.000000, '2024-04-20'),
	(41, 'Pago de salarios', 1700.000000, '2024-05-01'),
	(42, 'Compra de materiales', 350.000000, '2024-05-02'),
	(43, 'Pago de alquiler', 1400.000000, '2024-05-04'),
	(44, 'Gastos de publicidad', 490.000000, '2024-05-06'),
	(45, 'Compra de equipo', 910.000000, '2024-05-07'),
	(46, 'Pago de servicios', 300.000000, '2024-05-10'),
	(47, 'Gastos operativos', 340.000000, '2024-05-12'),
	(48, 'Pago de impuestos', 680.000000, '2024-05-14'),
	(49, 'Gastos de publicidad', 540.000000, '2024-05-17'),
	(50, 'Pago de proveedores', 780.000000, '2024-05-20');

-- Volcando estructura para tabla sistemagestiongimnasio.entrenadores
CREATE TABLE IF NOT EXISTS `entrenadores` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Correo` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `usuario_id` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.entrenadores: ~3 rows (aproximadamente)
INSERT INTO `entrenadores` (`id`, `Nombre`, `Correo`, `usuario_id`) VALUES
	(2, 'Alejandro Solano Jimenez', 'ajsol2021@yahoo.com', 2),
	(3, 'Veronica Solis Castro', 'vero_sol92@grupoinsp.com', 3),
	(5, 'Andrea Mora Salas', 'andre.morsl@outlook.com', 5);

-- Volcando estructura para tabla sistemagestiongimnasio.facturas
CREATE TABLE IF NOT EXISTS `facturas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `numero_factura` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `fecha_emision` date NOT NULL,
  `fecha_vencimiento` date NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `matricula_id` int NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `numero_factura` (`numero_factura`),
  KEY `matricula_id` (`matricula_id`),
  CONSTRAINT `facturas_ibfk_1` FOREIGN KEY (`matricula_id`) REFERENCES `matriculas` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.facturas: ~1 rows (aproximadamente)
INSERT INTO `facturas` (`id`, `numero_factura`, `fecha_emision`, `fecha_vencimiento`, `total`, `matricula_id`, `created_at`, `updated_at`) VALUES
	(1, 'FAC12345', '2024-12-01', '2024-12-31', 100.00, 1, '2024-12-09 01:42:42', '2024-12-09 01:42:42');

-- Volcando estructura para tabla sistemagestiongimnasio.facturas_items
CREATE TABLE IF NOT EXISTS `facturas_items` (
  `id` int NOT NULL AUTO_INCREMENT,
  `factura_id` int NOT NULL,
  `descripcion` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `cantidad` int NOT NULL,
  `precio_unitario` decimal(10,2) NOT NULL,
  `total_item` decimal(10,2) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `factura_id` (`factura_id`),
  CONSTRAINT `facturas_items_ibfk_1` FOREIGN KEY (`factura_id`) REFERENCES `facturas` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.facturas_items: ~1 rows (aproximadamente)
INSERT INTO `facturas_items` (`id`, `factura_id`, `descripcion`, `cantidad`, `precio_unitario`, `total_item`, `created_at`, `updated_at`) VALUES
	(1, 1, 'Matrícula mensual', 1, 100.00, 100.00, '2024-12-09 01:42:42', '2024-12-09 01:42:42');

-- Volcando estructura para tabla sistemagestiongimnasio.informecontable
CREATE TABLE IF NOT EXISTS `informecontable` (
  `Fecha` date NOT NULL,
  `Descripcion` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Ingreso` int NOT NULL,
  `Gasto` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.informecontable: ~3 rows (aproximadamente)
INSERT INTO `informecontable` (`Fecha`, `Descripcion`, `Ingreso`, `Gasto`) VALUES
	('2024-07-23', 'Pago de Membresia', 349800, 0),
	('2024-06-14', 'Servicio de Limpieza', 0, 281600),
	('2024-01-13', 'Cobro por Clases Personalizadas', 441650, 0);

-- Volcando estructura para tabla sistemagestiongimnasio.ingresos
CREATE TABLE IF NOT EXISTS `ingresos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(255) COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `monto` decimal(20,6) NOT NULL DEFAULT '0.000000',
  `fecha` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.ingresos: ~50 rows (aproximadamente)
INSERT INTO `ingresos` (`id`, `descripcion`, `monto`, `fecha`) VALUES
	(1, 'Venta de membresías', 500.000000, '2024-01-01'),
	(2, 'Pago de clases particulares', 300.000000, '2024-01-02'),
	(3, 'Venta de productos', 150.000000, '2024-01-03'),
	(4, 'Ingreso por evento', 1000.000000, '2024-01-05'),
	(5, 'Donación', 200.000000, '2024-01-06'),
	(6, 'Pago de cuotas mensuales', 400.000000, '2024-01-07'),
	(7, 'Venta de merchandising', 250.000000, '2024-01-10'),
	(8, 'Venta de entradas', 350.000000, '2024-01-12'),
	(9, 'Ingreso por evento', 1500.000000, '2024-01-15'),
	(10, 'Donación', 500.000000, '2024-01-16'),
	(11, 'Pago de cuotas mensuales', 420.000000, '2024-02-01'),
	(12, 'Venta de productos', 180.000000, '2024-02-02'),
	(13, 'Pago de clases particulares', 350.000000, '2024-02-04'),
	(14, 'Ingreso por evento', 1200.000000, '2024-02-06'),
	(15, 'Donación', 250.000000, '2024-02-07'),
	(16, 'Pago de cuotas mensuales', 450.000000, '2024-02-10'),
	(17, 'Venta de merchandising', 300.000000, '2024-02-12'),
	(18, 'Venta de entradas', 400.000000, '2024-02-14'),
	(19, 'Ingreso por evento', 1700.000000, '2024-02-17'),
	(20, 'Donación', 600.000000, '2024-02-20'),
	(21, 'Pago de cuotas mensuales', 430.000000, '2024-03-01'),
	(22, 'Venta de productos', 160.000000, '2024-03-02'),
	(23, 'Pago de clases particulares', 300.000000, '2024-03-05'),
	(24, 'Ingreso por evento', 1100.000000, '2024-03-08'),
	(25, 'Donación', 350.000000, '2024-03-09'),
	(26, 'Pago de cuotas mensuales', 460.000000, '2024-03-12'),
	(27, 'Venta de merchandising', 280.000000, '2024-03-14'),
	(28, 'Venta de entradas', 450.000000, '2024-03-16'),
	(29, 'Ingreso por evento', 1600.000000, '2024-03-20'),
	(30, 'Donación', 550.000000, '2024-03-21'),
	(31, 'Pago de cuotas mensuales', 440.000000, '2024-04-01'),
	(32, 'Venta de productos', 170.000000, '2024-04-02'),
	(33, 'Pago de clases particulares', 380.000000, '2024-04-04'),
	(34, 'Ingreso por evento', 1300.000000, '2024-04-06'),
	(35, 'Donación', 300.000000, '2024-04-08'),
	(36, 'Pago de cuotas mensuales', 470.000000, '2024-04-10'),
	(37, 'Venta de merchandising', 320.000000, '2024-04-12'),
	(38, 'Venta de entradas', 460.000000, '2024-04-14'),
	(39, 'Ingreso por evento', 1800.000000, '2024-04-17'),
	(40, 'Donación', 700.000000, '2024-04-20'),
	(41, 'Pago de cuotas mensuales', 460.000000, '2024-05-01'),
	(42, 'Venta de productos', 190.000000, '2024-05-02'),
	(43, 'Pago de clases particulares', 310.000000, '2024-05-04'),
	(44, 'Ingreso por evento', 1400.000000, '2024-05-06'),
	(45, 'Donación', 400.000000, '2024-05-07'),
	(46, 'Pago de cuotas mensuales', 480.000000, '2024-05-10'),
	(47, 'Venta de merchandising', 330.000000, '2024-05-12'),
	(48, 'Venta de entradas', 470.000000, '2024-05-14'),
	(49, 'Ingreso por evento', 1900.000000, '2024-05-17'),
	(50, 'Donación', 750.000000, '2024-05-20');

-- Volcando estructura para tabla sistemagestiongimnasio.inventario
CREATE TABLE IF NOT EXISTS `inventario` (
  `id` int NOT NULL AUTO_INCREMENT,
  `NombreEquipo` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Categoria` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `FechaAdquisicion` date NOT NULL,
  `VidaUtilDias` int NOT NULL,
  `Estado` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.inventario: ~3 rows (aproximadamente)
INSERT INTO `inventario` (`id`, `NombreEquipo`, `Categoria`, `FechaAdquisicion`, `VidaUtilDias`, `Estado`) VALUES
	(1, 'Bicicleta Estatica', 'Otro', '2023-09-22', 2, 'Activo'),
	(2, 'Caminadora', 'Electronico', '2021-11-02', 9, 'Inactivo'),
	(3, 'Eliptica', 'Otro', '2022-06-23', 10, 'Activo');

-- Volcando estructura para tabla sistemagestiongimnasio.matriculas
CREATE TABLE IF NOT EXISTS `matriculas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cliente_id` int DEFAULT NULL,
  `membresia_id` int DEFAULT NULL,
  `cliente_nombre` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `monto_matricula` decimal(20,6) DEFAULT NULL,
  `fecha_matricula` date DEFAULT NULL,
  `metodo_pago` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.matriculas: ~40 rows (aproximadamente)
INSERT INTO `matriculas` (`id`, `cliente_id`, `membresia_id`, `cliente_nombre`, `monto_matricula`, `fecha_matricula`, `metodo_pago`) VALUES
	(1, 101, 1, 'Juan Pérez', 100.000000, '2024-01-15', 'Tarjeta de Crédito'),
	(2, 102, 2, 'Ana García', 120.000000, '2024-01-20', 'Efectivo'),
	(3, 103, 3, 'Carlos Ruiz', 90.000000, '2024-01-22', 'Transferencia'),
	(4, 104, 4, 'Laura Sánchez', 110.000000, '2024-02-05', 'Tarjeta de Crédito'),
	(5, 105, 5, 'Miguel López', 95.000000, '2024-02-07', 'Efectivo'),
	(6, 106, 6, 'Sofía Torres', 130.000000, '2024-02-10', 'Tarjeta de Crédito'),
	(7, 107, 7, 'Luis Martínez', 85.000000, '2024-02-12', 'Transferencia'),
	(8, 108, 8, 'Paola Fernández', 115.000000, '2024-03-01', 'Efectivo'),
	(9, 109, 9, 'Javier García', 120.000000, '2024-03-03', 'Tarjeta de Crédito'),
	(10, 110, 10, 'Elena Ramírez', 100.000000, '2024-03-05', 'Efectivo'),
	(11, 111, 11, 'Pedro González', 110.000000, '2024-03-10', 'Transferencia'),
	(12, 112, 12, 'Marta Rodríguez', 130.000000, '2024-03-15', 'Tarjeta de Crédito'),
	(13, 113, 13, 'José Pérez', 95.000000, '2024-04-01', 'Efectivo'),
	(14, 114, 14, 'María Fernández', 125.000000, '2024-04-03', 'Tarjeta de Crédito'),
	(15, 115, 15, 'Luis Martínez', 105.000000, '2024-04-05', 'Transferencia'),
	(16, 116, 16, 'Claudia Sánchez', 110.000000, '2024-04-08', 'Efectivo'),
	(17, 117, 17, 'Felipe López', 95.000000, '2024-04-10', 'Tarjeta de Crédito'),
	(18, 118, 18, 'Isabel Rodríguez', 120.000000, '2024-04-12', 'Efectivo'),
	(19, 119, 19, 'Ricardo Gómez', 90.000000, '2024-04-15', 'Transferencia'),
	(20, 120, 20, 'Andrea García', 100.000000, '2024-04-18', 'Efectivo'),
	(21, 121, 1, 'Juan Pérez', 100.000000, '2024-05-01', 'Tarjeta de Crédito'),
	(22, 122, 2, 'Ana García', 120.000000, '2024-05-03', 'Efectivo'),
	(23, 123, 3, 'Carlos Ruiz', 90.000000, '2024-05-05', 'Transferencia'),
	(24, 124, 4, 'Laura Sánchez', 110.000000, '2024-05-07', 'Tarjeta de Crédito'),
	(25, 125, 5, 'Miguel López', 95.000000, '2024-05-10', 'Efectivo'),
	(26, 126, 6, 'Sofía Torres', 130.000000, '2024-05-12', 'Tarjeta de Crédito'),
	(27, 127, 7, 'Luis Martínez', 85.000000, '2024-05-14', 'Transferencia'),
	(28, 128, 8, 'Paola Fernández', 115.000000, '2024-06-01', 'Efectivo'),
	(29, 129, 9, 'Javier García', 120.000000, '2024-06-03', 'Tarjeta de Crédito'),
	(30, 130, 10, 'Elena Ramírez', 100.000000, '2024-06-05', 'Efectivo'),
	(31, 131, 11, 'Pedro González', 110.000000, '2024-06-10', 'Transferencia'),
	(32, 132, 12, 'Marta Rodríguez', 130.000000, '2024-06-15', 'Tarjeta de Crédito'),
	(33, 133, 13, 'José Pérez', 95.000000, '2024-07-01', 'Efectivo'),
	(34, 134, 14, 'María Fernández', 125.000000, '2024-07-03', 'Tarjeta de Crédito'),
	(35, 135, 15, 'Luis Martínez', 105.000000, '2024-07-05', 'Transferencia'),
	(36, 136, 16, 'Claudia Sánchez', 110.000000, '2024-07-08', 'Efectivo'),
	(37, 137, 17, 'Felipe López', 95.000000, '2024-07-10', 'Tarjeta de Crédito'),
	(38, 138, 18, 'Isabel Rodríguez', 120.000000, '2024-07-12', 'Efectivo'),
	(39, 139, 19, 'Ricardo Gómez', 90.000000, '2024-07-15', 'Transferencia'),
	(40, 140, 20, 'Andrea García', 100.000000, '2024-07-18', 'Efectivo');

-- Volcando estructura para tabla sistemagestiongimnasio.membresias
CREATE TABLE IF NOT EXISTS `membresias` (
  `id` int NOT NULL,
  `usuario_id` int NOT NULL,
  `FechaInicio` date NOT NULL,
  `FechaFin` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.membresias: ~3 rows (aproximadamente)
INSERT INTO `membresias` (`id`, `usuario_id`, `FechaInicio`, `FechaFin`) VALUES
	(1, 1, '2024-11-15', '2024-11-27'),
	(2, 2, '2025-01-01', '2025-02-01'),
	(3, 3, '2024-12-23', '2025-01-23');

-- Volcando estructura para tabla sistemagestiongimnasio.metricas_progreso
CREATE TABLE IF NOT EXISTS `metricas_progreso` (
  `id` int NOT NULL AUTO_INCREMENT,
  `usuario_id` int NOT NULL,
  `parte` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `cantidad` int NOT NULL,
  `fecha` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `usuario_id` (`usuario_id`),
  CONSTRAINT `metricas_progreso_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.metricas_progreso: ~6 rows (aproximadamente)
INSERT INTO `metricas_progreso` (`id`, `usuario_id`, `parte`, `cantidad`, `fecha`) VALUES
	(1, 1, 'pierna', 11, '2024-12-17 19:06:09'),
	(2, 1, 'torso', 14, '2024-12-17 19:07:33'),
	(3, 1, 'pierna', 11, '2024-12-17 19:12:33'),
	(4, 1, 'pierna', 14, '2024-12-17 19:22:03'),
	(5, 1, 'pecho', 65, '2024-12-17 19:22:03'),
	(6, 2, 'Piernas', 10, '2024-12-20 17:52:31');

-- Volcando estructura para tabla sistemagestiongimnasio.plan
CREATE TABLE IF NOT EXISTS `plan` (
  `id` int NOT NULL,
  `nombre` varchar(50) COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.plan: ~1 rows (aproximadamente)
INSERT INTO `plan` (`id`, `nombre`) VALUES
	(1, 'PLATINO');

-- Volcando estructura para tabla sistemagestiongimnasio.reportemembresia
CREATE TABLE IF NOT EXISTS `reportemembresia` (
  `FechaRegistro` date NOT NULL,
  `MembresiasNuevas` int NOT NULL,
  `TotalMembresias` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.reportemembresia: ~4 rows (aproximadamente)
INSERT INTO `reportemembresia` (`FechaRegistro`, `MembresiasNuevas`, `TotalMembresias`) VALUES
	('2024-11-01', 5, 105),
	('2024-11-02', 6, 111),
	('2024-11-03', 7, 118),
	('2024-11-04', 5, 123);

-- Volcando estructura para tabla sistemagestiongimnasio.reservas
CREATE TABLE IF NOT EXISTS `reservas` (
  `Clase` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Fecha` date NOT NULL,
  `Cliente` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Clase`,`Fecha`,`Cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.reservas: ~4 rows (aproximadamente)
INSERT INTO `reservas` (`Clase`, `Fecha`, `Cliente`) VALUES
	('CrossFit', '2024-08-11', 'Ana Martinez Jimenez'),
	('Ejercicios variados para activar todo el cuerpo', '2024-11-16', 'Jose Mora Lopez'),
	('Spinning', '2025-01-02', 'Jose Mora Lopez'),
	('Yoga Matutino', '2024-12-24', 'Jose Ramirez Aguilar');

-- Volcando estructura para tabla sistemagestiongimnasio.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `ID` int NOT NULL,
  `Nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Correo` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Tipo` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `Usuario` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `Contraseña` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Telefono` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla sistemagestiongimnasio.usuarios: ~5 rows (aproximadamente)
INSERT INTO `usuarios` (`ID`, `Nombre`, `Correo`, `Tipo`, `Usuario`, `Contraseña`, `Telefono`) VALUES
	(1, 'Jose Mora Lopez', 'josemora@gmail.com', 'Cliente', 'jmora8tg', 'jose1687', '26468094'),
	(2, 'Jose Mora Lopez', 'josmlo1987@racsa.com', 'Cliente', 'jmoralyb8', 'jose4613', '26468094'),
	(3, 'Veronica Solis Castro', 'vero_sol92@grupoinsp.com', 'Entrenador', 'entrenador', 'entrenador', '26468094'),
	(4, 'Jose Mora Lopez', 'josmlo1987@racsa.com', 'Administrador', 'administrador', 'administrador', '26468094'),
	(5, 'Andrea Mora Salas', 'andre.morsl@outlook.com', 'Entrenador', 'entrenador', 'entrenador', '26468094');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
