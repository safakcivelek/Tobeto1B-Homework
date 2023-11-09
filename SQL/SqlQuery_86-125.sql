---***SQL SORGULARI (86-125)***---
----------------------------------
--86. a.Bu ülkeler hangileri..?
-- (ihracat yaptığım ülkeler)
SELECT Distinct ship_country
FROM Orders

--87. En Pahalı 5 ürün
SELECT product_name,unit_price
FROM Products
ORDER BY unit_price desc
limit 5

--88. ALFKI CustomerID’sine sahip müşterimin sipariş sayısı..?
SELECT  c.customer_id,Count(c.customer_id)
FROM CUSTOMERS c
     JOIN Orders o on c.customer_id = o.customer_id
WHERE c.customer_id= 'ALFKI'
GROUP BY  c.customer_id

--89. Ürünlerimin toplam maliyeti
SELECT SUM(od.quantity*p.unit_price) AS "TOPLAM MALİYET"
FROM Products P
     JOIN Order_DEtails od on p.product_id = od.product_id

--90. Şirketim, şimdiye kadar ne kadar ciro yapmış..?
--1. Yöntem 
SELECT SUM(od.unit_price * od.quantity - (od.unit_price * od.quantity * od.discount))
FROM Order_details od
     JOIN Products p on od.product_id = p.product_id   
-- 2. Yöntem
SELECT SUM( (od.unit_price * od.quantity * (1-od.discount)))
FROM Order_details od
     JOIN Products p on od.product_id = p.product_id   

--91. Ortalama Ürün Fiyatım
SELECT AVG(unit_price)
FROM PRODUCTs

--92. En Pahalı Ürünün Adı
SELECT product_name,unit_price
FROM PRODUCTS
ORDER BY unit_price DESC
LIMIT 1

--93. En az kazandıran sipariş 
SELECT (od.unit_price * (1-od.discount) * od.quantity) AS TOTAL 
FROM Orders o
     JOIN order_details od on o.order_id = od.order_id
ORDER BY TOTAL asc
limit 1

--94. Müşterilerimin içinde en uzun isimli müşteri
SELECT *
FROM CUSTOMERS
order by length(company_name) desc
limit 5

--95. Çalışanlarımın Ad, Soyad ve Yaşları
SELECT
    first_name AS "Ad",
    last_name AS "Soyad",
    EXTRACT(YEAR FROM AGE(birth_date)) AS "Yaş"
FROM 
    employees
--"AGE" fonksiyonu, doğum tarihinden itibaren geçen süreyi hesaplar

--96. Hangi üründen toplam kaç adet alınmış..?
SELECT p.product_name,sum(od.quantity) AS TOTAL
FROM Order_details od
     JOIN Products p on od.product_id = p.product_id
Group by p.product_name
ORDER BY TOTAL DESC 

--97. Hangi siparişte toplam ne kadar kazanmışım..?
SELECT o.order_id ,SUM( od.quantity * od.unit_price * (1-od.discount) ) AS TOTAL
FROM Orders o
     JOIN order_details od on o.order_id = od.order_id
GROUP BY o.order_id
ORDER BY TOTAL DESC

--98. Hangi kategoride toplam kaç adet ürün bulunuyor..?
SELECT c.category_name ,COUNT(p.product_id)
FROM Products p
     JOIN Categories c on p.category_id = c.category_id
	 JOIN Order_Details od on p.product_id = od.product_id
Group by c.category_name

--99. 1000 Adetten fazla satılan ürünler?
SELECT p.product_name ,SUM(od.quantity) AS TOTAL
FROM Products p
     JOIN order_details od on p.product_id = od.product_id
GROUP BY  p.product_name
HAVING SUM(od.quantity) > 1000
ORDER BY TOTAL

--100. Hangi Müşterilerim hiç sipariş vermemiş..?
SELECT c.company_name,o.order_id
FROM CUSTOMERS c
      LEFT JOIN Orders o on c.customer_id = o.customer_id
WHERE o.order_id IS NULL

--101. Hangi tedarikçi hangi ürünü sağlıyor ?
SELECT p.product_name,s.company_name
FROM SUPPLIERS s
     JOIN Products p on p.supplier_id = s.supplier_id
ORDER BY p.product_name

--102. Hangi sipariş hangi kargo şirketi ile ne zaman gönderilmiş..?
SELECT s.company_name ,o.shipped_date
FROM Orders o
     JOIN Shippers s on o.ship_via = s.shipper_id 
ORDER BY o.shipped_date

--103. Hangi siparişi hangi müşteri verir..?
SELECT o.order_id , c.company_name
FROM Orders o
     JOIN Customers c on o.customer_id = c.customer_id
ORDER BY o.order_id

--104. Hangi çalışan, toplam kaç sipariş almış..?
SELECT  CONCAT(e.first_name ,' ',e.last_name) AS "AD-SOYAD",COUNT(o.order_id) AS TOPLAM
FROM Orders o
     JOIN Employees e on o.employee_id = e.employee_id
Group By "AD-SOYAD"

--105. En fazla siparişi kim almış..?
SELECT  CONCAT(e.first_name ,' ',e.last_name) AS "AD-SOYAD",COUNT(o.order_id) AS TOPLAM
FROM Orders o
     JOIN Employees e on o.employee_id = e.employee_id
Group By "AD-SOYAD"
ORDER BY TOPLAM DESC
limit 1

--106. Hangi siparişi, hangi çalışan, hangi müşteri vermiştir..?
SELECT o.order_id, CONCAT(e.first_name ,' ',e.last_name),c.company_name
FROM Orders o
     JOIN Employees e on o.employee_id = e.employee_id
	 JOIN Customers c on o.customer_id = c.customer_id

--107. Hangi ürün, hangi kategoride bulunmaktadır..? Bu ürünü kim tedarik etmektedir..?
SELECT p.product_name, c.category_name,s.company_name
FROM Products p
     JOIN Categories c on p.category_id = c.category_id
	 JOIN Suppliers s on p.supplier_id = s.supplier_id

--108. Hangi siparişi hangi müşteri vermiş, hangi çalışan almış, hangi tarihte, hangi kargo şirketi tarafından gönderilmiş hangi üründen kaç adet alınmış,
--hangi fiyattan alınmış, ürün hangi kategorideymiş bu ürünü hangi tedarikçi sağlamış
SELECT 
  p.product_name,
  c.category_name,
  sp.company_name,
  CONCAT(e.first_name ,' ',e.last_name),
  cs.company_name,
  o.order_date,
  sh.company_name,
  od.quantity,
  od.unit_price

FROM Orders o
     JOIN Customers cs on o.customer_id = cs.customer_id
	 JOIN Employees e on o.employee_id = e.employee_id
	 JOIN Shippers sh on o.ship_via = sh.shipper_id
	 JOIN Order_details od on o.order_id = od.order_id
	 JOIN Products p on od.product_id = p.product_id	 
	 JOIN Categories c on p.category_id = c.category_id
	 JOIN Suppliers sp on p.supplier_id = sp.supplier_id

--109. Altında ürün bulunmayan kategoriler
SELECT c.category_name , p.product_name 
FROM Categories c
     LEFT JOIN Products p on p.category_id = c.category_id
WHERE p.product_id IS NULL

--110. Manager ünvanına sahip tüm müşterileri listeleyiniz.
Select*
FROM Customers 
WHERE contact_title LIKE  '%Manager%'

--111. FR ile başlayan 5 karekter olan tüm müşterileri listeleyiniz.
SELECT customer_id,
    SUBSTRING(company_name FROM 1 FOR 5) AS "Name"
FROM customers
WHERE 
    UPPER(SUBSTRING(company_name FROM 1 FOR 2)) = 'FR'
	
--112. (171) alan kodlu telefon numarasına sahip müşterileri listeleyiniz.
SELECT *
FROM Customers
WHERE phone LIKE '(171)%'

--113. Birimdeki Miktar alanında boxes geçen tüm ürünleri listeleyiniz.
SELECT *
FROM PRODUCTS
WHERE quantity_per_unit LIKE '%boxes%'

--114. Fransa ve Almanyadaki (France,Germany) Müdürlerin (Manager) Adını ve Telefonunu listeleyiniz.(MusteriAdi,Telefon)
SELECT company_name,CONTACT_title,phone
FROM CUSTOMERS
WHERE country IN ('France','Germany') AND contact_title LIKE '%Manager%'

--115. En yüksek birim fiyata sahip 10 ürünü listeleyiniz.
SELECT unit_price
FROM Products
ORDER BY unit_price DESC
limit 10

--116. Müşterileri ülke ve şehir bilgisine göre sıralayıp listeleyiniz.
SELECT company_name,country,city
FROM CUSTOMERS 
ORDER BY country,city

--117. Personellerin ad,soyad ve yaş bilgilerini listeleyiniz.
SELECT
    first_name AS "Ad",
    last_name AS "Soyad",
    EXTRACT(YEAR FROM AGE(birth_date)) AS "Yaş"
FROM 
    employees

--118. 35 gün içinde sevk edilmeyen satışları listeleyiniz.
SELECT  *
FROM Orders
WHERE shipped_Date-required_Date  > 35 OR shipped_date IS NULL

--119. Birim fiyatı en yüksek olan ürünün kategori adını listeleyiniz. (Alt Sorgu)
SELECT c.category_name
FROM Categories c 
Where c.category_id=(Select p.category_id from Products p Order By p.unit_price desc
Limit 1
)

--120. Kategori adında 'on' geçen kategorilerin ürünlerini listeleyiniz. (Alt Sorgu)
select p.product_name from products p 
WHERE p.category_id IN (select c.category_id from categories c
      where c.category_name LIKE '%on%')

--121. Konbu adlı üründen kaç adet satılmıştır.
sELECT SUM(quantity)
FROM order_Details 
Where product_id =  (SELECT product_id
  FROM PRODUCTS
  WHERE product_name = 'Konbu') 

--122. Japonyadan kaç farklı ürün tedarik edilmektedir.
SELECT Count(DISTINCT p.product_name)
FROM Products p
     JOIN Suppliers s on p.supplier_id = s.supplier_id
WHERE s.country = 'Japan'

--123. 1997 yılında yapılmış satışların en yüksek, en düşük ve ortalama nakliye ücretlisi ne kadardır?
SELECT MAX(freight),MIN(freight),AVG(freight)
FROM ORDERS 
WHERE Extract(YEAR FROM order_date)= 1997

--124. Faks numarası olan tüm müşterileri listeleyiniz.
SELECT *
FROM Customers 
WHERE fax is not null 

--125. 1996-07-16 ile 1996-07-30 arasında sevk edilen satışları listeleyiniz. 
SELECT *
FROM ORDERS 
WHERE Shipped_date between '1996-07-16' and '1996-07-30'
