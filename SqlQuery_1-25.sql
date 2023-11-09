﻿--SORU-1 Product isimlerini (`ProductName`) ve birim başına miktar (`QuantityPerUnit`) değerlerini almak için sorgu yazın.
SELECT  product_name, Quantity_Per_Unit
FROM Products 

--SORU-2  Ürün Numaralarını (`ProductID`) ve Product isimlerini (`ProductName`) değerlerini almak için sorgu yazın.
--Artık satılmayan ürünleri (`Discontinued`) filtreleyiniz.
SELECT Product_ID, Product_Name ,Discontinued
FROM products
where Discontinued = 0

--SORU-3 Durdurulan Ürün Listesini, Ürün kimliği ve ismi (`ProductID`, `ProductName`) değerleriyle almak için bir sorgu yazın.
SELECT Product_ID, Product_Name ,Discontinued
FROM products
where Discontinued = 1

--SORU-4 Ürünlerin maliyeti 20'dan az olan Ürün listesini (`ProductID`, `ProductName`, `UnitPrice`) almak için bir sorgu yazın.
SELECT Product_ID, Product_Name ,unit_price
FROM products
where unit_price < 20
Order by unit_price

--SORU-5 Ürünlerin maliyetinin 15 ile 25 arasında olduğu Ürün listesini (`ProductID`, `ProductName`, `UnitPrice`) almak için bir sorgu yazın.
SELECT Product_ID, Product_Name ,unit_price
FROM products
WHERE unit_price between 15 and 25
Order by unit_price

--SORU-6 Ürün listesinin (`ProductName`, `UnitsOnOrder`, `UnitsInStock`) stoğun siparişteki miktardan az olduğunu almak için bir sorgu yazın.
select product_name,Units_On_Order,Units_In_Stock
from products
where Units_In_Stock < Units_On_Order

--SORU-7 İsmi `a` ile başlayan ürünleri listeleyeniz.
select PRODUCT_NAME
from products
where upper(product_name) LIKE 'A%'

--SORU-8 İsmi `i` ile biten ürünleri listeleyeniz.
select PRODUCT_NAME
from products
where product_name LIKE '%i'

--SORU-9 Ürün birim fiyatlarına %18’lik KDV ekleyerek listesini almak (ProductName, UnitPrice, UnitPriceKDV) için bir sorgu yazın.
SELECT product_name , unit_price ,unit_price*1.18 as KDV_FİYAT
from products

--SORU-10 Fiyatı 30 dan büyük kaç ürün var?
SELECT count(*) as Adet
FROM PRODUCTS
WHERE unit_price > 30

--SORU-11 Ürünlerin adını tamamen küçültüp fiyat sırasına göre tersten listele
select lower(product_name), unit_price
from products
order by unit_price desc

--SORU-12 Çalışanların ad ve soyadlarını yanyana gelecek şekilde yazdır
select CONCAT(first_name ,' ', last_name)
from employees

--SORU-13 Region alanı NULL olan kaç tedarikçim var?
select Count(company_name)
from suppliers
where region is NULL

--SORU-14 a.Null olmayanlar?
select Count(*) 
from suppliers
where region is NOT NULL

--SORU-15 Ürün adlarının hepsinin soluna TR koy ve büyültüp olarak ekrana yazdır.
SELECT 'TR '|| upper(product_name)
from products

SELECT CONCAT('TR ',Upper(product_name))
from products

--SORU-16 a.Fiyatı 20den küçük ürünlerin adının başına TR ekle
SELECT 'TR '|| upper(product_name) ,unit_price
from products
WHERE unit_price < 20
order by unit_price

--SORU-17 En pahalı ürün listesini (`ProductName` , `UnitPrice`) almak için bir sorgu yazın.
select product_name,unit_price
from products
order by unit_price desc

select product_name,unit_price
from products
order by unit_price desc
limit 1

--SORU-18 En pahalı on ürünün Ürün listesini (`ProductName` , `UnitPrice`) almak için bir sorgu yazın.
select product_name, unit_price
from products
ORDER BY unit_price desc
limit 10

--SORU-19 Ürünlerin ortalama fiyatının üzerindeki Ürün listesini (`ProductName` , `UnitPrice`) almak için bir sorgu yazın.
select product_name,unit_price
from products
where (select AVG(unit_price)from products) < unit_price
order by unit_price

--SORU-20 Stokta olan ürünler satıldığında elde edilen miktar ne kadardır.
Select Sum(unit_price * units_in_stock) from products where units_in_stock > 0

SELECT SUM(Toplam) AS Toplamkazanc
FROM (
    SELECT Product_ID, SUM(Unit_Price * Units_In_Stock) AS Toplam
    FROM Products
    WHERE Units_In_Stock > 0
    GROUP BY Product_ID)
	
	
--SORU-21 Mevcut ve Durdurulan ürünlerin sayılarını almak için bir sorgu yazın.
select *
from products 
where units_in_stock > 0 and discontinued = 1

--SORU-22 Ürünleri kategori isimleriyle birlikte almak için bir sorgu yazın.
select P.product_name, C.category_name
from products as P
     JOIN categories as C on P.category_id = C.category_id

--SORU-23 Ürünlerin kategorilerine göre fiyat ortalamasını almak için bir sorgu yazın.
select  C.category_name, AVG(p.unit_price) AS Ortalama_Fiyat
from products as P
     JOIN categories as C on P.category_id = C.category_id
Group By c.category_name
	 	 
--SORU-24 En pahalı ürünümün adı, fiyatı ve kategorisin adı nedir?
select P.product_name,C.category_name,P.unit_price
from products as P
     JOIN categories as C on P.category_id = C.category_id
ORDER BY P.unit_price desc
limit 1

--SORU-25 En çok satılan ürününün adı, kategorisinin adı ve tedarikçisinin adı

select P.product_id, P.product_name,C.category_name,S.company_name,SUM(OD.quantity) AS TOTAL
from products as P
     JOIN categories as C on P.category_id = C.category_id
	 JOIN suppliers as S on P.supplier_id = S.supplier_id
	 JOIN order_details as OD on OD.product_id = P.product_id
	 
Group By  P.product_id,P.product_name,C.category_name,S.company_name
ORDER BY TOTAL desc
limit 1
