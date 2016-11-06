/*
 Prikazuju prezime i ime glumaca, kao i naziv sezone u kojoj su igrali ulogu
  Kir Dime u predstavi „Kir Janja“. 
  Rezultat sortirati u rastućem redosledu naziva sezone i 
  opadajućem redosledu prezimena glumca. 
*/
select glu.IME,glu.PREZIME,pos.NAZIV_SEZONE
from dbo.GLUMAC glu join dbo.POSTAVA pos
	on glu.GLUMID = pos.GLUMID
	join dbo.PREDSTAVA pre
	on pre.PREDID = pos.PREDID
where  pre.NAZIV = 'Kir Janja'
	   and 
	   pos.ULOGA = 'Kir Dime'
order by pos.NAZIV_SEZONE asc, glu.PREZIME desc;
