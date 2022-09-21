create database votingSystem

use votingSystem

select * from tblParty
select * from tblVoter
select * from tblBooth

delete from tblPartyVoted
create table tblPartyVoted(PartyIdVoted int foreign key references tblparty(PartyID), VoterIdVoted int foreign key references tblVoter(voterID) );
insert into tblPartyVoted(PartyIdVoted) values(1)

create table tblparty(PartyID int identity(1,1) primary key, partyName varchar(10), partySymbol varchar(10))
insert into tblparty  values('congress','hand')
insert into tblparty values('bjp','lotus')

create table tblParty(PartyID int identity(1,1) primary key, partyName varchar(10), partySymbol varchar(10), votedId int foreign key references tblVoter(voterID))

drop table tblParty
select * from tblvoter
create table Voter(voterID int identity(1000,1) primary key, voterName varchar(20),DOB date, AdharCard varchar(16), Pancard varchar(10), password varchar(6))
drop table tblVoter
create table tblBooth(BoothID int identity(1,1) primary key, location varchar(20), starttiming datetime, endtiming datetime)

drop table tblBooth
insert into tblParty values('Congress','Hand',1)

insert into tblVoter values('Adam','2000-02-14','999888','A33332','1234')
insert into tblVoter values('Bob','2000-12-14','1234567','Pantest','Bob1')

insert into tblBooth values('Pune','1/10/2022 10:00:00 AM','1/10/2022 5:00:00 PM')


insert into VoterBoothRelation values(2,1000)
create table VoterBoothRelation(BoothID int foreign key references tblBooth(BoothID),voterId int foreign key references tblVoter(voterID))


select tblVoter.voterName,tblBooth.location,tblBooth.starttiming,tblBooth.endtiming from tblBooth join VoterBoothRelation on  VoterBoothRelation.BoothID=tblBooth.BoothID join tblVoter on VoterBoothRelation.voterId=tblVoter.voterID

create procedure LocationAssignDetails

as
select tblVoter.voterName,tblBooth.location,tblBooth.starttiming,tblBooth.endtiming,tblVoter.password,tblVoter.voterID from tblBooth join VoterBoothRelation on  VoterBoothRelation.BoothID=tblBooth.BoothID join tblVoter on VoterBoothRelation.voterId=tblVoter.voterID
go

exec LocationAssignDetails

create table voterCount(PartyId int foreign key references tblParty(PartyID), VoterId int foreign key references tblVoter(voterID));

select * from voterCount

select PartyId,count(*) as votecount from voterCount group by PartyId