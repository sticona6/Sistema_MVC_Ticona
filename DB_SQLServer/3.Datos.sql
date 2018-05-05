USE db_galeria_web2
GO

insert into dbo.Categoria (nombre, descripcion, estado) values ('Cursos', 'Categoria 1 xxxxxx', 'A')
go
insert into dbo.Categoria (nombre, descripcion, estado) values ('Horarios', 'Categoria 2 xxxxxx', 'A')
go
insert into dbo.Categoria (nombre, descripcion, estado) values ('Docentes', 'Categoria 3 xxxxxx', 'A')
go
insert into dbo.Categoria (nombre, descripcion, estado) values ('Estudiantes', 'Categoria 3 xxxxxx', 'A')
go



insert Into dbo.Persona (dni, apellido, nombre, email, celular, estado)
               Values ('12345678','Lanchipa Valencia', 'Enrique','elanchipa@upt.pe', '', 'A')
go
insert Into dbo.Persona (dni, apellido, nombre, email, celular, estado)
               Values ('223344','Ale Nieto', 'Tito','tito@gmail.com', '', 'A')
go
insert Into dbo.Persona (dni, apellido, nombre, email, celular, estado)
               Values ('87654321','Rodriguez Marca', 'Elard','elardroma@hotmail.com', '', 'A')
go
insert Into dbo.Persona (dni, apellido, nombre, email, celular, estado)
               Values ('87654322','Ludmer Arcaya', 'Larcaya','larcaya@hotmail.com', '', 'I')
go

insert Into dbo.Usuario (persona_id, usuario, clave, nivel, avatar, estado) 
                 values (1, 'elanchipa', '123456', 'Administrador','foto1.jpg', 'A')
go
insert Into dbo.Usuario (persona_id, usuario, clave, nivel, avatar, estado) 
                 values (2, 'tale', '1234', 'Supervisor','foto2.jpg', 'A')
go
insert Into dbo.Usuario (persona_id, usuario, clave, nivel, avatar, estado)
                 values (3, 'eladroma', '123', 'Usuario','foto3.jpg', 'A')
go
insert Into dbo.Usuario (persona_id, usuario, clave, nivel, avatar, estado)
                 values (4, 'larcaya', '123', 'Usuario','foto4.jpg', 'I')
go

insert Into dbo.Documento (categoria_id, nombre, descripcion, extension, tamanio, tipo, estado) 
                 values (1, 'Lista de estudiantes', 'Es de caracter muy importante', '.doc', '20 MB', 'Documento', 'A')
go
insert Into dbo.Documento (categoria_id, nombre, descripcion, extension, tamanio, tipo, estado) 
                 values (2, 'Lista de docentes', 'Es de caracter muy importante', '.doc', '20 MB', 'Documento', 'A')
go
insert Into dbo.Documento (categoria_id, nombre, descripcion, extension, tamanio, tipo, estado) 
                 values (3, 'Lista de estudiantes y docentes', 'Es de caracter muy importante', '.doc', '20 MB', 'Documento', 'A')
go

insert Into dbo.Galeria (categoria_id, nombre, descripcion, imagen, thumbail, estado) 
                 values (1, 'Galeria 1 xxxxxx', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean placerat. Aliquam erat volutpat.', '', '20 MB', 'A')
go
insert Into dbo.Galeria (categoria_id, nombre, descripcion, imagen, thumbail, estado) 
                 values (2, 'Galeria 2 xxxxxx', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean placerat. Aliquam erat volutpat.', '', '20 MB', 'A')
go
insert Into dbo.Galeria (categoria_id, nombre, descripcion, imagen, thumbail, estado) 
                 values (3, 'Galeria 3 xxxxxx', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean placerat. Aliquam erat volutpat.', '', '20 MB', 'A')
go

select * from Categoria
go
select * from Persona
go
select * from Usuario
go
select * from Documento
go
select * from Galeria
go




