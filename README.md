# easyFood

An ordering platform for restaurant.

## System Design

### 1 堂食

### 用户端：

	- 可登陆系统、查看订单

	- 可选择桌号

	- 可浏览菜品（种类、图片、价格、简介），可点击菜品查看细节（材料、说明）、可把菜品添加至购物车

	- 可浏览购物车，并增减购物车内菜品、针对各项菜品添加特殊要求，可在购物车点击下单 ->实时发送订餐至厨房端

	- 可观察菜品制作状态

### 厨房端

	- 实时接收订单，可更新菜品制作状态

### admin端

	- 浏览桌子占用状态、浏览桌子预定情况、增改桌子预定情况

	- 不同人数排号系统

	- 查看各桌菜单情况、增减菜单菜品、结账

	- 支付管理系统

	- 管理注册用户、查看用户历史订单

### Entity

    - User (email,name,phone,password,birthday, role, *Order)

    - Order (Time, *FoodItem, Total Cost, Status(Cooking, Unpaid, Paid), User )

    - FoodItem (*Food, Quantity)

    - FoodCart (Time, *FoodItem, Total Cost, Status(Cooking, Unpaid, Paid), User)

    - Table (id, Status(Booked,Free,Ocupied,Closed),NumberOfPeople, *Order, User )

    - Food (name, Price, PictureUrl, Summary, Material, Description, stockStatus (empty, inStock), Category)

    - Category (name, Food)

    - Queue (QueueId, User, NumberOfPeople, Time)

    - Payment  (TBD...)

### Function

User:

	- User: register(user,password), login(user,password), logout(user), getUser(userId), updateUser(userId, user), deleteUser(userId)

	- Admin: login(user,password), logout(user), addUser(user,password), setUserRole(userId, userRole),getUsers(), getUser(userId), updateUser(userId, user), deleteUser(userId)
 
Order:

	- User: addOrder(order), viewOrders(userId), viewOrder(orderId),updateOrder(orderId, order), deleteOrder(orderId)

	- Admin: viewOrders(), viewOrders(),viewOrder(orderId), updateOrder(orderId, order), deleteOrder(orderId)

	- Kitchen: updateOrder(orderId, order)

Table:

	- Admin: addTable(table), bookTable(tableId, status.book), occupyTable(tableId, status.occupied), closeTable(tableId, status.closed), freeTable(tableId, status.free), updateTable(tableId, table), deleteTabe(tableId)

	- User: occupyTable(tableId,status.occupied)

Category:

	- Admin: addCategory(category), updateCategory(categoryId, category), deleteCategory(categoryId)

Food:

	- Admin: addFood(food),updateFood(foodId, food), deleteFood(foodId), viewFoods(), viewFood(foodId)

	- User: viewFoodsByCategory(CategoryId), viewFood(foodId)

FoodCart:

	- User: AddToCart(foodId), ViewCart(), checkout(), updateCart(cartId,cart)

Queue:

	- User: addQueue(queue)

	- Admin: addQueue(queue), deleteQueue(queueId), viewQueues(),viewQueue(queueId)
	

### Tech Stacks

    - Order, Queue -> websocket
    
    - Database: mongoDB

    - Back-end: .net core/go

    - Front-end: react

### UI Design

TBD