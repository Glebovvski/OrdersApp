declare @start datetime = '11.11.2017'
declare @end datetime = '12.01.2018'

select o1.Manager , ( select  count(*) as [Amount of orders] from Orders o2
	where 
		o1.Manager = o2.Manager 
		AND
		o2.CreateDate >= CONVERT(datetime, @start)
		AND 
		o2.EndDate <= CONVERT(datetime, @end)
) from Orders o1
group by o1.Manager