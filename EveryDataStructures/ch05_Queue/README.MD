# 队列：先入先出的数据集

队列queue，抽象化的数据结构，将对象组织为线性的数据集  
先入先出FIFO：First-In First-Out  
入队enqueue，加入队尾  
出队dequeue，删除队首

数组队列和链表队列

栈可以是已排序或未排序  
队列，根本不是未排序而设计的；如果新加对象就排序，操作代价令人吃惊O(nlog(n))  
优先级队列prioity queue，基于堆，支持排序，但代价依然高昂，只有特殊场合使用  

## 初始化

C#：
```csharp
    Queue<Customer> customers= new Queue<Customer>();
    customers.Enqueue(new Customer());
    customers.Dequeue();
```

## 案例学习：客户服务

参考代码示例：QueueTest.CustomerQueue()  

## 高级话题

根据不同的底层数据结构，构建不同的队列  
各有优劣

### 数组队列

array-based queue，可变数组  
位置0表示队首或队尾；FIFO，一般不考虑排序，开销太大  

### 链表队列

linked list-based queue，指针指向队首元素，并将新对象的后续指针添加进数据集  
出队操作，只是i结案的那的移动队首指针  
需要数据集为已排序队列时，应使用链表队列  

### 堆队列

heap-based queue，通过对数据集创建  
专门的树形数据结构(tree-based data structure)，其中的对象会根据值或原生属性自然地升序(最小堆，min heap)或降序(最大堆，max heap)排列

### 双端队列

double-ended queue，支持在队首或队尾增加或删除对象  
如Java中的`ArrayQueue<E>`  

### 优先级队列

priority queue，将数据集中的对象按照一些值或优先级排序  
由于堆的分层结构特性，优先级队列常以堆队列的形式实现  
更高优先级的对象，排在队列的前部  
先出队的对象，都是最高优先级的对象；或者同等优先级中，等待时间最久的对象  
