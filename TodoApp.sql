create database db_todo
use db_todo

create table todoApp(
	TodoID int identity(1,1) primary key,
	Descript varchar(50)
)

create proc Insert_Func 'Ali'
@description varchar(50)
as
begin
insert into todoApp(descript)values(@description)
end

create proc Get_Func
as
begin
select* from todoApp
end

create proc Delete_Func
@todoID int
as
begin
delete from todoApp where TodoID=@todoID
end

create proc Update_Func 
@todoID int,
@description varchar(50)
as
begin 
update todoApp
set Descript=@description
where TodoID=@todoID
end