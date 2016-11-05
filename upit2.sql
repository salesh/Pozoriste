select TOP 1 rep.PREDID, pre.NAZIV
from dbo.REPERTOAR rep join dbo.PREDSTAVA pre
	on rep.PREDID = pre.PREDID
where year(rep.DATUMIVREME) = year(getdate())
group by rep.PREDID,pre.NAZIV
order by count(*) desc;