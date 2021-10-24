-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 27-09-2020 a las 00:44:02
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `agrodinas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cultivos`
--

CREATE TABLE `cultivos` (
  `idCultivos` int(11) NOT NULL COMMENT 'Almacenara el id de cultivo con el cual se podra identificar que cultivo es de cada partida y de cual jugador\n',
  `TamañoDeCultivo` int(11) DEFAULT NULL COMMENT 'Almacena el tamaño del cultivo respecto al pasar el tiempo en el sotfware',
  `TiempoDeVida` varchar(45) DEFAULT NULL COMMENT 'el tiempo de vida que tiene cada cultivo\n\n\n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `decisiones`
--

CREATE TABLE `decisiones` (
  `idDecisiones` int(11) NOT NULL COMMENT 'Almacena el id de decision con lo cual se logra identificar que decisiones realiza el usuario en toda la partida\n',
  `Valor` int(11) DEFAULT NULL COMMENT 'Me almacena el costo o valor de la decision tomada por el usuario\n',
  `Tiempo` time DEFAULT NULL COMMENT 'Me almacena el tiempo que dura la decision\n',
  `CantidadDeRecurso` int(11) NOT NULL,
  `idTipoDeDecisiones` int(11) NOT NULL COMMENT 'Almacena los tipos de desiciones realizadas por el usuario durante la partida\n',
  `idPartidas` int(11) NOT NULL COMMENT 'Me almacena todas las decisiones que el usuario haga respecto a la partida.\n',
  `idRecursos` int(11) NOT NULL COMMENT 'Me almacena todos los recursos  que el usuario haga respecto a la partida. por ejemplo Agua, ya que el agua sera comunitaria para todos los jugadores\n\n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado`
--

CREATE TABLE `estado` (
  `idEstado` int(11) NOT NULL COMMENT 'Almacena el tipo de estado por ejemplo Activo o inactivo \n',
  `TipoDeEstado` varchar(45) NOT NULL COMMENT 'Especifica el tipo de estado en el que esta el usuario\n',
  `DescripcionDeEstado` varchar(45) DEFAULT NULL COMMENT 'Describe el tipo de estado que esta el usuario\nInactivo: no puede ingresar al juego ya que fue inactivado por no jugar\nActivo: Puede ingresar al juego y jugar cuando desee'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `estado`
--

INSERT INTO `estado` (`idEstado`, `TipoDeEstado`, `DescripcionDeEstado`) VALUES
(1, 'Activo', 'Puede ingresar al software'),
(2, 'Inactivo', 'No puede ingresar al software hasta que el ad');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `partidas`
--

CREATE TABLE `partidas` (
  `idPartida` int(11) NOT NULL COMMENT 'Almacena el id de partida con la cual se podra identificar \n\n',
  `FechasDePartida` date DEFAULT current_timestamp() COMMENT 'Almacena la fecha en la que se inicia una partida',
  `idUsuario` int(11) NOT NULL COMMENT 'Almacena el usuario que esta en la partida',
  `Ganancias` int(11) DEFAULT NULL COMMENT 'Almacena las ganancias que va a tener el usuario en la partida',
  `Perdidas` int(11) DEFAULT NULL COMMENT 'Almacena las perdidas que va a tener el usuario en la partida',
  `FechaDeFinalizacion` date DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `procesodecultivo`
--

CREATE TABLE `procesodecultivo` (
  `Cultivos_idCultivos` int(11) NOT NULL COMMENT 'Almacena el cultivo de la partida',
  `Partidas_idPartidas` int(11) NOT NULL COMMENT 'almacena la partida del cultivo',
  `CantidadDeProducto` int(11) DEFAULT NULL COMMENT 'Almacena la cantidad del producto generado de acuerdo al cultivo',
  `ValorDeProducto` int(11) DEFAULT NULL COMMENT 'Almacena el valor al cual se vende el producto generado del cultivo\n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recursos`
--

CREATE TABLE `recursos` (
  `idRecursos` int(11) NOT NULL COMMENT 'Almacena el id de recu',
  `TipoDeRecurso` int(11) DEFAULT NULL,
  `CantidadDeRecurso` int(11) DEFAULT NULL,
  `Descripcion` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `idRol` int(11) NOT NULL COMMENT 'Almacena el id de los roles los cuales son (1. Administrador y 2.Jugador)\n\n',
  `TipoDeRol` varchar(45) NOT NULL COMMENT 'Especifica cual sera el tipo de rol (Jugador o administrador)\n',
  `DescripcionDeRol` varchar(45) DEFAULT NULL COMMENT 'Almacena la respectiva descripcion del tipo de rol almacenado\n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`idRol`, `TipoDeRol`, `DescripcionDeRol`) VALUES
(1, 'Administrador', 'Tiene acceso a todo el sistema, puede crear u'),
(2, 'Jugador', 'Tiene acceso al sistema de aprendizaje pero n');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipodedecisiones`
--

CREATE TABLE `tipodedecisiones` (
  `idTipoDeDecisiones` int(11) NOT NULL COMMENT 'Almacena el tipo de decision que usara el usuario para mantener el cultivo o para vender \n',
  `TipoDeDecision` varchar(45) NOT NULL COMMENT 'almacena la el nombre de la decision que tome el usuario \n\n',
  `DescripcionDeDecision` varchar(45) DEFAULT NULL COMMENT 'Especifica la desicion que toma el usuario para mantener sus cultivos o vender entre otras.\n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipodeplanta`
--

CREATE TABLE `tipodeplanta` (
  `idTipoDePlanta` int(11) NOT NULL COMMENT 'Almacenara el tipo de platan que cultivaremos(maiz,tomate)',
  `TipoDePlanta` varchar(45) NOT NULL COMMENT 'Almacenara el nombre del tipo de planta que cultivaremos ejemplo: Maiz\n',
  `Descripcion` varchar(45) DEFAULT NULL COMMENT 'Almacenara la descripcion de la planta que el usuario va a cultivar\n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipodeplantavscultivos`
--

CREATE TABLE `tipodeplantavscultivos` (
  `TipoDePlanta_idTipoDePlanta` int(11) NOT NULL COMMENT 'Almacena el tipo de planta que vamos a cultivar\n',
  `Cultivos_idCultivos` int(11) NOT NULL COMMENT 'Almacena el cultivo donde se almacenara el tipo de planta\n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `idUsuario` int(11) NOT NULL COMMENT 'Almacena el id de cada usuario que ingrese al software de aprendizaje \n\n',
  `NombreDeUsuario` varchar(45) NOT NULL COMMENT 'almacena el nombre de cada usuario \n\n',
  `ApellidoDelUsuario` varchar(45) NOT NULL COMMENT 'Almacena el apellido de cada usuario ',
  `FechaDeNacimiento` date NOT NULL COMMENT 'Almacena la fecha de nacimiento para asi calcular su edad en la actualidad de cada usuario\n\n',
  `usuario` varchar(45) NOT NULL COMMENT 'almacena el Correo del usuario con el cual podra iniciar sesion para ingresar el software\n\n',
  `Clave` varchar(45) NOT NULL COMMENT 'Almacena la contraseña del usuario para ingresar al software por medio del login ',
  `idRol` int(11) DEFAULT NULL COMMENT 'Llave foranea de la tabla "Roles" con esto se sabra que tipo de rol es el usuario\n',
  `Estado_idEstado` int(11) NOT NULL COMMENT 'Me representa en que estado esta el usuario si esta activo o inactivo \n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`idUsuario`, `NombreDeUsuario`, `ApellidoDelUsuario`, `FechaDeNacimiento`, `usuario`, `Clave`, `idRol`, `Estado_idEstado`) VALUES
(1, 'Sebastian', 'Veloza', '2000-05-19', 'admin', '123456', 1, 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cultivos`
--
ALTER TABLE `cultivos`
  ADD PRIMARY KEY (`idCultivos`);

--
-- Indices de la tabla `decisiones`
--
ALTER TABLE `decisiones`
  ADD PRIMARY KEY (`idDecisiones`),
  ADD KEY `fk_Desiciones_TipoDeDesiciones1` (`idTipoDeDecisiones`),
  ADD KEY `fk_Desiciones_Partidas1` (`idPartidas`),
  ADD KEY `fk_Decisiones_Recursos1` (`idRecursos`);

--
-- Indices de la tabla `estado`
--
ALTER TABLE `estado`
  ADD PRIMARY KEY (`idEstado`);

--
-- Indices de la tabla `partidas`
--
ALTER TABLE `partidas`
  ADD PRIMARY KEY (`idPartida`),
  ADD KEY `fk_Partidas_Usuarios1` (`idUsuario`);

--
-- Indices de la tabla `procesodecultivo`
--
ALTER TABLE `procesodecultivo`
  ADD KEY `fk_Cultivos_has_Partidas_Cultivos1` (`Cultivos_idCultivos`),
  ADD KEY `fk_Cultivos_has_Partidas_Partidas1` (`Partidas_idPartidas`);

--
-- Indices de la tabla `recursos`
--
ALTER TABLE `recursos`
  ADD PRIMARY KEY (`idRecursos`);

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`idRol`);

--
-- Indices de la tabla `tipodedecisiones`
--
ALTER TABLE `tipodedecisiones`
  ADD PRIMARY KEY (`idTipoDeDecisiones`);

--
-- Indices de la tabla `tipodeplanta`
--
ALTER TABLE `tipodeplanta`
  ADD PRIMARY KEY (`idTipoDePlanta`);

--
-- Indices de la tabla `tipodeplantavscultivos`
--
ALTER TABLE `tipodeplantavscultivos`
  ADD KEY `fk_TipoDePlanta_has_Cultivos_TipoDePlanta1` (`TipoDePlanta_idTipoDePlanta`),
  ADD KEY `fk_TipoDePlanta_has_Cultivos_Cultivos1` (`Cultivos_idCultivos`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`idUsuario`),
  ADD KEY `Rol` (`idRol`),
  ADD KEY `fk_Usuarios_Estado1` (`Estado_idEstado`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cultivos`
--
ALTER TABLE `cultivos`
  MODIFY `idCultivos` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Almacenara el id de cultivo con el cual se podra identificar que cultivo es de cada partida y de cual jugador\n';

--
-- AUTO_INCREMENT de la tabla `decisiones`
--
ALTER TABLE `decisiones`
  MODIFY `idDecisiones` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Almacena el id de decision con lo cual se logra identificar que decisiones realiza el usuario en toda la partida\n';

--
-- AUTO_INCREMENT de la tabla `estado`
--
ALTER TABLE `estado`
  MODIFY `idEstado` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Almacena el tipo de estado por ejemplo Activo o inactivo \n', AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `partidas`
--
ALTER TABLE `partidas`
  MODIFY `idPartida` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Almacena el id de partida con la cual se podra identificar \n\n';

--
-- AUTO_INCREMENT de la tabla `recursos`
--
ALTER TABLE `recursos`
  MODIFY `idRecursos` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Almacena el id de recu';

--
-- AUTO_INCREMENT de la tabla `roles`
--
ALTER TABLE `roles`
  MODIFY `idRol` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Almacena el id de los roles los cuales son (1. Administrador y 2.Jugador)\n\n', AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `tipodedecisiones`
--
ALTER TABLE `tipodedecisiones`
  MODIFY `idTipoDeDecisiones` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Almacena el tipo de decision que usara el usuario para mantener el cultivo o para vender \n';

--
-- AUTO_INCREMENT de la tabla `tipodeplanta`
--
ALTER TABLE `tipodeplanta`
  MODIFY `idTipoDePlanta` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Almacenara el tipo de platan que cultivaremos(maiz,tomate)';

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `idUsuario` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Almacena el id de cada usuario que ingrese al software de aprendizaje \n\n', AUTO_INCREMENT=2;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `decisiones`
--
ALTER TABLE `decisiones`
  ADD CONSTRAINT `fk_Decisiones_Recursos1` FOREIGN KEY (`idRecursos`) REFERENCES `recursos` (`idRecursos`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Desiciones_Partidas1` FOREIGN KEY (`idPartidas`) REFERENCES `partidas` (`idPartida`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Desiciones_TipoDeDesiciones1` FOREIGN KEY (`idTipoDeDecisiones`) REFERENCES `tipodedecisiones` (`idTipoDeDecisiones`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `partidas`
--
ALTER TABLE `partidas`
  ADD CONSTRAINT `fk_Partidas_Usuarios1` FOREIGN KEY (`idUsuario`) REFERENCES `usuarios` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `procesodecultivo`
--
ALTER TABLE `procesodecultivo`
  ADD CONSTRAINT `fk_Cultivos_has_Partidas_Cultivos1` FOREIGN KEY (`Cultivos_idCultivos`) REFERENCES `cultivos` (`idCultivos`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Cultivos_has_Partidas_Partidas1` FOREIGN KEY (`Partidas_idPartidas`) REFERENCES `partidas` (`idPartida`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tipodeplantavscultivos`
--
ALTER TABLE `tipodeplantavscultivos`
  ADD CONSTRAINT `fk_TipoDePlanta_has_Cultivos_Cultivos1` FOREIGN KEY (`Cultivos_idCultivos`) REFERENCES `cultivos` (`idCultivos`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_TipoDePlanta_has_Cultivos_TipoDePlanta1` FOREIGN KEY (`TipoDePlanta_idTipoDePlanta`) REFERENCES `tipodeplanta` (`idTipoDePlanta`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `Rol` FOREIGN KEY (`idRol`) REFERENCES `roles` (`idRol`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Usuarios_Estado1` FOREIGN KEY (`Estado_idEstado`) REFERENCES `estado` (`idEstado`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
