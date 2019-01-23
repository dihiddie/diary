create table diary_post
(
id int not null primary key identity,
title varchar(max) null, 
createDateTime datetime not null default getDate(),
updateDateTime datetime null,
content varbinary(max) not null
)