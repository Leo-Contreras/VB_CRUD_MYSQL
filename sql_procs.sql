create database CRUD
go

use CRUD
go

create table Empleados
(
cod_emp char(5) primary key not null,
usr_nom varchar(50),
usr_direccion varchar(50),
fecha_ing date,
fecha_ter date,
ar_trabajo char(1)
)
go


-----------------LISTADO-------------------------------
create proc pb_listar
as
select * from Empleados
go

-------------------REGISTRO----------------------------------
create proc pb_nuevo
@nombre varchar(50),
@direccion varchar(50),
@fechaing date,
@fechater date,
@area char(1)
as
declare @codigonuevo varchar(5)
set @codigonuevo = (select MAX(cod_emp) from Empleados)
set @codigonuevo = 'g' + RIGHT ('0000' + LTRIM (right(isnull(@codigonuevo,'0000'),4)+1),4)
insert into Empleados values (@codigonuevo,@nombre,@direccion,@fechaing,@fechater,@area)
go

-----------ELIMINAR-------------------

create proc pb_eliminar
@codigo char(5)
As
delete from Empleados where cod_emp = @codigo
go


------------MODIFICAR-------------------
create proc pb_modificar
@codigo char(5),
@nombre varchar(50),
@direccion varchar(50),
@fechaing date,
@fechater date,
@area char(1)
as
update Empleados set  usr_nom = @nombre,
usr_direccion = @direccion,
fecha_ing = @fechaing,
fecha_ter = @fechater,
ar_trabajo = @area
where cod_emp = @codigo
go

-------------INSERT EXAMPLE-----------------------------------------


insert into Empleados values ('g0001' , 'Leo' , 'Laguna Victoria 4612' , '1997-08-20' , '2022-12-05' , 1)
insert into Empleados values ('g0002' , 'Reoskor' , 'Laguna Victoria 4612' , '1997-08-20' , '2022-12-05' , 2)
insert into Empleados values ('g0003' , 'Kim' , 'Laguna Victoria 4612' , '1997-08-20' , '2022-12-05' , 5 )
insert into Empleados values ('g0004' , 'Kakas' , 'Laguna Victoria 4612' , '1997-08-20' , '2022-12-05' , 2 )
insert into Empleados values ('g0005' , 'Sergio' , 'Laguna Victoria 4612' , '1997-08-20' , '2022-12-05' , 3 )

-------------RUN PROCEDURE EXAMPLE -----------------------------------------

exec pb_listar
go