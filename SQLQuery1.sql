declare @start datetime = 12/02/2017
declare @end datetime = 12/01/2018

/*
select Orders.Manager, COUNT(Orders.Manager) as [Amount of orders] from Orders  

	
where Orders.CreateDate>=CONVERT(datetime,'11.11.2017') AND Orders.EndDate <= CONVERT(datetime,'12/01/2018') 

	group by Orders.Manager
*/

select  Orders.Manager, 
'Amount of orders' = case

when CreateDate>=CONVERT(datetime,'11.11.2017') AND EndDate <= CONVERT(datetime,'12/01/2018') then COUNT(Orders.Manager)  

else 0

end 

from Orders 

group by Orders.Manager ,Orders.CreateDate,Orders.EndDate