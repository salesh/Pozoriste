/*
Kreira pogled PREGLED_GLUMACA(GLUMACID, PREZIME, IME, BROJ_PREDSTAVA_08_09,
BROJ_PREDSTAVA_09_10) kojim se za svakog glumca prikazuju šifra, prezime, ime, broj predstava u
čijim postavama je bio u sezoni „2008/2009“ i broj predstava u čijim postavama je bio u sezoni
„2009/2010“. U obzir uzeti samo glumce koji su u svojoj karijeri bili u postavama više od 20 različitih
predstava i kod kojih je broj komedija u čijim postavama su bili u sezoni „2009/2010“ veći od broja
komedija u čijim postavama su bili u sezoni „2008/2009“. 
*/

create view PREGLED_GLUMACA(GLUMACID,PREZIME,IME,BROJ_PREDSTAVA_08_09,BROJ_PREDSTAVA_09_10) as
with razlicite as(
	select pos.GLUMID uspeh
	from dbo.GLUMAC glu join dbo.POSTAVA pos
			on glu.GLUMID = pos.GLUMID
		 join dbo.PREDSTAVA pre
			on pre.PREDID = pos.PREDID
    group by pos.GLUMID
	having count(distinct pos.PREDID) >= 20
),
pom1 as (
	select pos.GLUMID idGlumca ,
		 count(*) brPred
	from razlicite r join dbo.POSTAVA pos
		on r.uspeh = pos.GLUMID
	join dbo.PREDSTAVA pre
		on pre.PREDID = pos.PREDID
	where pos.NAZIV_SEZONE = '2008/2009'
		and pre.TIP = 'KOMEDIJA'
	group by pos.GLUMID
),
pom2 as (
	select pos.GLUMID idGlumca ,
		count(*) brPred
	from razlicite r join dbo.POSTAVA pos
		on r.uspeh = pos.GLUMID
	join dbo.PREDSTAVA pre
		on pre.PREDID = pos.PREDID
	where pos.NAZIV_SEZONE = '2009/2010'
		and pre.TIP = 'KOMEDIJA'
	group by pos.GLUMID
),
pom3 as (
	select p1.idGlumca idGlumca
 	from pom1 p1 join pom2 p2
		on p1.idGlumca = p2.idGlumca
	where p2.brPred > p1.brPred
),
pom4 as (
	select pos.GLUMID idGlumaca ,
		count(
		case when pos.NAZIV_SEZONE = '2008/2009' then 1
		else  null
		end) ukGodina1,
		count(
		case when pos.NAZIV_SEZONE = '2009/2010' then 1
		else  null
		end) ukGodina2
	from pom3 p3 join dbo.POSTAVA pos
		on p3.idGlumca = pos.GLUMID
	join dbo.PREDSTAVA pre
		on pre.PREDID = pos.PREDID
	group by pos.GLUMID
)
select glu.GLUMID, glu.PREZIME, glu.IME, p4.ukGodina1, p4.ukGodina2
from pom4 p4 join dbo.GLUMAC glu
	on p4.idGlumaca = glu.GLUMID
