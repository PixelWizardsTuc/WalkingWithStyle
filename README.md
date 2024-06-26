# WalkingWithStyle

# KRAV

Fokuser på att få de grundläggande funktionalitet i uppgiften mer än på hur många sidor blir det i slutet. 
Att ni har ett admin och en vanlig användare. Kundregister där alla kan se lista av kunder medan admin kan redigera och lägga till kund. 
En produktkatalog med minst ett bild, beskrivning och pris, varukorg, orderhisprik. Bara admin kan hantera produkter. 
En kommentarsfunktion för produker för inloggad användare. 
Jag forsökte korta ner de viktiga delar, hoppas att det hjälper.

## NuGet packages:
* DocumentFormat.OpenXml (3.0.2)
* Microsoft.EntityFrameworkCore (8.0.3)
* Microsoft.EntityFrameworkCore.Design (8.0.3)
* Microsoft.EntityFrameworkCore.Tool (8.0.3)
* Microsoft.EntityFrameworkCore.SqlServer (8.0.3)

# DB:
-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- Link to schema: https://app.quickdatabasediagrams.com/#/d/bxmdCI
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.


SET XACT_ABORT ON

BEGIN TRANSACTION QUICKDBD

CREATE TABLE [Users] (
    [UserID] int  NOT NULL ,
    [UserName] varchar(20)  NOT NULL ,
    [Password] varchar(20)  NOT NULL ,
    [Email] varchar(20)  NOT NULL ,
    [ProfilePic] varchar(max)  NOT NULL ,
    [RegDate] date  NOT NULL ,
    [Role] varchar(20)  NOT NULL ,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED (
        [UserID] ASC
    )
)

CREATE TABLE [Customers] (
    [UserID] int  NOT NULL ,
    [FName] varchar(20)  NOT NULL ,
    [LName] varchar(20)  NOT NULL ,
    [Adress1] varchar(30)  NOT NULL ,
    [Adress2] varchar(30)  NOT NULL ,
    [Adress3] varchar(30)  NOT NULL ,
    [Phone1] int  NOT NULL ,
    [Phone2] int  NOT NULL ,
    [Phone3] int  NOT NULL ,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED (
        [UserID] ASC
    )
)

CREATE TABLE [Orders] (
    [OrderID] int  NOT NULL ,
    [UserID] int  NOT NULL ,
    [TotalAmount] money  NOT NULL ,
    [OrderDate] date  NOT NULL ,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED (
        [OrderID] ASC
    )
)

CREATE TABLE [ShoppingCart] (
    [CartID] int  NOT NULL ,
    [UserID] int  NOT NULL ,
    [ProductID] int  NOT NULL ,
    [Quantity] int  NOT NULL ,
    CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED (
        [CartID] ASC
    )
)

CREATE TABLE [OrderDetails] (
    [ODID] int  NOT NULL ,
    [OrderID] int  NOT NULL ,
    [ProductID] int  NOT NULL ,
    [Quantity] int  NOT NULL ,
    [PricePerUnit] money  NOT NULL ,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED (
        [ODID] ASC
    )
)

CREATE TABLE [Products] (
    [ProductID] int  NOT NULL ,
    [PName] varchar(200)  NOT NULL ,
    [Description] string  NOT NULL ,
    [Price] money  NOT NULL ,
    [Pic] varchar(max)  NOT NULL ,
    [Stock] int  NOT NULL ,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED (
        [ProductID] ASC
    )
)

CREATE TABLE [ForumThreads] (
    [ThreadID] int  NOT NULL ,
    [Heading] varchar(200)  NOT NULL ,
    [UserID] int  NOT NULL ,
    [CreationDate] datetime  NOT NULL ,
    CONSTRAINT [PK_ForumThreads] PRIMARY KEY CLUSTERED (
        [ThreadID] ASC
    )
)

CREATE TABLE [ForumPosts] (
    [PostID] int  NOT NULL ,
    [ThreadID] int  NOT NULL ,
    [Contents] nvarchar(max)  NOT NULL ,
    [UserID] int  NOT NULL ,
    [CreationDate] datetime  NOT NULL ,
    CONSTRAINT [PK_ForumPosts] PRIMARY KEY CLUSTERED (
        [PostID] ASC
    )
)

ALTER TABLE [Customers] WITH CHECK ADD CONSTRAINT [FK_Customers_UserID] FOREIGN KEY([UserID])
REFERENCES [Users] ([UserID])

ALTER TABLE [Customers] CHECK CONSTRAINT [FK_Customers_UserID]

ALTER TABLE [Orders] WITH CHECK ADD CONSTRAINT [FK_Orders_UserID] FOREIGN KEY([UserID])
REFERENCES [Customers] ([UserID])

ALTER TABLE [Orders] CHECK CONSTRAINT [FK_Orders_UserID]

ALTER TABLE [ShoppingCart] WITH CHECK ADD CONSTRAINT [FK_ShoppingCart_UserID] FOREIGN KEY([UserID])
REFERENCES [Customers] ([UserID])

ALTER TABLE [ShoppingCart] CHECK CONSTRAINT [FK_ShoppingCart_UserID]

ALTER TABLE [ShoppingCart] WITH CHECK ADD CONSTRAINT [FK_ShoppingCart_ProductID] FOREIGN KEY([ProductID])
REFERENCES [Products] ([ProductID])

ALTER TABLE [ShoppingCart] CHECK CONSTRAINT [FK_ShoppingCart_ProductID]

ALTER TABLE [OrderDetails] WITH CHECK ADD CONSTRAINT [FK_OrderDetails_OrderID] FOREIGN KEY([OrderID])
REFERENCES [Orders] ([OrderID])

ALTER TABLE [OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_OrderID]

ALTER TABLE [OrderDetails] WITH CHECK ADD CONSTRAINT [FK_OrderDetails_ProductID] FOREIGN KEY([ProductID])
REFERENCES [Products] ([ProductID])

ALTER TABLE [OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_ProductID]

ALTER TABLE [ForumThreads] WITH CHECK ADD CONSTRAINT [FK_ForumThreads_UserID] FOREIGN KEY([UserID])
REFERENCES [Users] ([UserID])

ALTER TABLE [ForumThreads] CHECK CONSTRAINT [FK_ForumThreads_UserID]

ALTER TABLE [ForumPosts] WITH CHECK ADD CONSTRAINT [FK_ForumPosts_ThreadID] FOREIGN KEY([ThreadID])
REFERENCES [ForumThreads] ([ThreadID])

ALTER TABLE [ForumPosts] CHECK CONSTRAINT [FK_ForumPosts_ThreadID]

ALTER TABLE [ForumPosts] WITH CHECK ADD CONSTRAINT [FK_ForumPosts_UserID] FOREIGN KEY([UserID])
REFERENCES [Users] ([UserID])

ALTER TABLE [ForumPosts] CHECK CONSTRAINT [FK_ForumPosts_UserID]

COMMIT TRANSACTION QUICKDBD



## Make a new query and add the following data then execute:
USE WalkingWithStyle;


INSERT INTO Products (ProductID, PName, Description, Price, Pic, Stock)
VALUES
    (1, 'Adidas Shoes', 'Description of Adidas Shoes', 50.00, '~/images/adidas-1853899_640.jpg', 10),
    (2, 'Beach Shoes', 'Description of Beach Shoes', 55.00, '~/images/beach-1057766_640.jpg', 20),
    (3, 'Black and White Shoes', 'Description of Black and White Shoes', 60.00, '~/images/black-and-white-1282292_640.jpg', 15),
    (4, 'Blue Shoes', 'Description of Blue Shoes', 65.00, '~/images/blue-2537963_640.jpg', 18),
    (5, 'Boot', 'Description of Boot', 70.00, '~/images/boot-2700477_640.jpg', 12),
    (6, 'Boots', 'Description of Boots', 75.00, '~/images/boots-1638873_640.jpg', 25),
    (7, 'Boots', 'Description of Boots', 80.00, '~/images/boots-181744_640.jpg', 30),
    (8, 'Boots', 'Description of Boots', 85.00, '~/images/boots-2353889_640.jpg', 22),
    (9, 'Boots', 'Description of Boots', 90.00, '~/images/boots-2374145_640.jpg', 17),
    (10, 'Converse Shoes', 'Description of Converse Shoes', 95.00, '~/images/converse-2387917_640.jpg', 28),
    (11, 'Converse Shoes', 'Description of Converse Shoes', 100.00, '~/images/converse-2521534_640.jpg', 14),
    (12, 'Converse Shoes', 'Description of Converse Shoes', 105.00, '~/images/converse-4367266_640.jpg', 19),
    (13, 'Converse Shoes', 'Description of Converse Shoes', 110.00, '~/images/converse-932667_640.jpg', 24),
    (14, 'Countryside Shoes', 'Description of Countryside Shoes', 115.00, '~/images/countryside-1846093_640.jpg', 21),
    (15, 'Fashion Shoes', 'Description of Fashion Shoes', 120.00, '~/images/fashion-2697009_640.jpg', 16),
    (16, 'Fashion Shoes', 'Description of Fashion Shoes', 125.00, '~/images/fashion-4013456_640.jpg', 23),
    (17, 'Fashion Shoes', 'Description of Fashion Shoes', 130.00, '~/images/fashion-5515135_640.jpg', 27),
    (18, 'Feet Shoes', 'Description of Feet Shoes', 135.00, '~/images/feet-1840619_640.jpg', 32),
    (19, 'Feet Shoes', 'Description of Feet Shoes', 140.00, '~/images/feet-349687_640.jpg', 26),
    (20, 'Green Shoes', 'Description of Green Shoes', 145.00, '~/images/green-932350_640.jpg', 18),
    (21, 'Grey Shoes', 'Description of Grey Shoes', 150.00, '~/images/grey-1838736_640.jpg', 14),
    (22, 'Kicks Shoes', 'Description of Kicks Shoes', 155.00, '~/images/kicks-2213619_640.jpg', 20),
    (23, 'Leather Shoes', 'Description of Leather Shoes', 160.00, '~/images/leather-shoes-505338_640.jpg', 17),
    (24, 'Nike Shoes', 'Description of Nike Shoes', 165.00, '~/images/nike-5020363_640.jpg', 23),
    (25, 'Nike Shoes', 'Description of Nike Shoes', 170.00, '~/images/nike-5020608_640.jpg', 29),
    (26, 'Nike Shoes', 'Description of Nike Shoes', 175.00, '~/images/nike-5126389_640.jpg', 31),
    (27, 'Nike Shoes', 'Description of Nike Shoes', 180.00, '~/images/nike-5418992_640.jpg', 25),
    (28, 'Outdoors Shoes', 'Description of Outdoors Shoes', 185.00, '~/images/outdoors-3243725_640.jpg', 19),
    (29, 'Product Shoes', 'Description of Product Shoes', 190.00, '~/images/product-2310506_640.jpg', 22),
    (30, 'Puma Shoes', 'Description of Puma Shoes', 195.00, '~/images/puma-1838735_640.jpg', 15),
    (31, 'Puma Shoes', 'Description of Puma Shoes', 200.00, '~/images/puma-3706914_640.jpg', 18),
    (32, 'Reebok Shoes', 'Description of Reebok Shoes', 205.00, '~/images/reebok-2061623_640.jpg', 24),
    (33, 'Running Shoe', 'Description of Running Shoe', 210.00, '~/images/running-shoe-321199_640.jpg', 28),
    (34, 'Running Shoe', 'Description of Running Shoe', 215.00, '~/images/running-shoe-423164_640.jpg', 34),
    (35, 'Shoes', 'Description of Shoes', 220.00, '~/images/shoes-1011596_640.jpg', 26),
    (36, 'Shoes', 'Description of Shoes', 225.00, '~/images/shoes-1433925_640.jpg', 32),
    (37, 'Shoes', 'Description of Shoes', 230.00, '~/images/shoes-1614047_640.jpg', 27),
    (38, 'Shoes', 'Description of Shoes', 235.00, '~/images/shoes-1897708_640.jpg', 21),
    (39, 'Shoes', 'Description of Shoes', 240.00, '~/images/shoes-2155404_640.jpg', 16),
    (40, 'Shoes', 'Description of Shoes', 245.00, '~/images/shoes-2216498_640.jpg', 22),
    (41, 'Shoes', 'Description of Shoes', 250.00, '~/images/shoes-2265959_640.jpg', 29),
    (42, 'Shoes', 'Description of Shoes', 255.00, '~/images/shoes-2334459_640.jpg', 33),
    (43, 'Shoes', 'Beskrivning av Shoes', 260.00, '~/images/shoes-343471_640.jpg', 161),
    (44, 'Shoes', 'Beskrivning av Shoes', 265.00, '~/images/shoes-3850175_640.jpg', 166),
    (45, 'Shoes', 'Beskrivning av Shoes', 270.00, '~/images/shoes-4158783_640.jpg', 171),
    (46, 'Shoes', 'Beskrivning av Shoes', 275.00, '~/images/shoes-434918_640.jpg', 176),
    (47, 'Shoes', 'Beskrivning av Shoes', 280.00, '~/images/shoes-4890686_640.jpg', 181),
    (48, 'Shoes', 'Beskrivning av Shoes', 285.00, '~/images/shoes-4955029_640.jpg', 186),
    (49, 'Shoes', 'Beskrivning av Shoes', 290.00, '~/images/shoes-959340_640.jpg', 191),
    (50, 'Slippers', 'Beskrivning av Slippers', 295.00, '~/images/slippers-5510231_640.jpg', 196),
    (51, 'Sneaker Shoes', 'Beskrivning av Sneaker Shoes', 300.00, '~/images/sneaker-1024981_640.jpg', 201),
    (52, 'Sneaker Shoes', 'Beskrivning av Sneaker Shoes', 305.00, '~/images/sneaker-5067977_640.jpg', 206),
    (53, 'Sneakers Shoes', 'Beskrivning av Sneakers Shoes', 310.00, '~/images/sneakers-2853769_640.jpg', 211),
    (54, 'Sneakers Shoes', 'Beskrivning av Sneakers Shoes', 315.00, '~/images/sneakers-3714730_640.jpg', 216),
    (55, 'Sneakers Shoes', 'Beskrivning av Sneakers Shoes', 320.00, '~/images/sneakers-6632816_640.jpg', 221),
    (56, 'Sneakers Shoes', 'Beskrivning av Sneakers Shoes', 325.00, '~/images/sneakers-8001394_640.jpg', 226),
    (57, 'Sports Shoes', 'Beskrivning av Sports Shoes', 330.00, '~/images/sports-shoe-2465915_640.jpg', 231),
    (58, 'Vans Shoes', 'Beskrivning av Vans Shoes', 335.00, '~/images/vans-shoes-5244832_640.jpg', 236),
    (59, 'Woman Shoes', 'Beskrivning av Woman Shoes', 340.00, '~/images/woman-2609573_640.jpg', 241),
    (60, 'Woman Shoes', 'Beskrivning av Woman Shoes', 345.00, '~/images/woman-3377839_640.jpg', 246);
