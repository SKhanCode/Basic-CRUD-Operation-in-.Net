create database rForInter

use rForInter

create table employee(
	empid int primary key identity,
	ename varchar(50),
	eage int,
	edepartment varchar(50),
	epost varchar(50)

)
TRUNCATE TABLE employee

select * from employee

create proc showemp
as
begin 
		select * from employee
		left join tbldepartment on edepartment=did
		left join tblpost on epost=pid

end

create proc showempWIthOutDropDown
as
begin 
		select * from employee
		
end
create proc insertemp
@ename varchar(50),
@eage int,
@edepartment varchar(50),
@epost varchar(50)

as
begin 
	insert into employee (ename,eage,edepartment,epost)values(@ename,@eage,@edepartment,@epost)
end

create proc updateemp
@eid int,
@ename varchar(50),
@eage int,
@edepartment varchar(50),
@epost varchar(50)
as
begin
		update employee set  ename=@ename, eage=@eage, edepartment=@edepartment, epost=@epost where empid=@eid

end

create proc deleteemp
@eid int
as
begin 
	delete from employee where empid=@eid
end


create proc editemp
@eid int
as
begin
		select * from employee where empid=@eid
end

create table tbldepartment(
did int primary key identity,
dname varchar(50)

)


create table tblpost(
pid int primary key identity,
pname varchar(50)

)

insert into tbldepartment(dname)values('IT'), ('HR'),('Accounts'), ('Security');

insert into tblpost(pname)values('Junior'), ('Senior'),('Manager');

create proc showdepartment
as
begin
		select * from tbldepartment
end


create proc showpost
as
begin
		select * from tblpost
end
