# 列表：线性数据集

列表，改良的数组  
数组：具体的数据结构  
列表：数据结构的一种抽象概念  
表头head，表尾tail；长度为1的列表，头和尾是同一个对象  

顺序表ordered list  
排序表sorted list  
空间关系spatial relationship  

## 列表的实现

- 数组表(array-based list)。仅存储数组位置的连续表，每一项都有指向数组元素的指针  
- 链表(linked list/singly linked list)。包含节点node，不以数组结构存储，而是内存中的指针来确定链表的第一个节点，每个节点还包含指向后一个节点的指针  
- 双链表(doubly linked list)。和链表类似，但是支持双向遍历，因为每个节点都包含指向前、后两个节点的指针。头节点的前向指针、尾节点的后向指针指空  
- 循环链表(circular linked list)。和双链表类似，但是将头、尾节点进行了链接  

### 数组表

- 添加元素，末尾添加元素，操作代价O(1)  
- 插入元素，在列表中任意位置插入元素，最坏情况为表头位置插入，故操作代价O(n)  
- 删除元素，在列表中任意位置删除元素，最坏情况为表头位置删除，故操作代价O(n)  

### 链表

- 添加元素，操作代价O(1)  
- 插入元素，操作代价O(1)  
- 删除元素，操作代价O(1)  

关键：链表中的元素，是离散的对象。对链表的操作，其实是对指针的修改。故，链表可以非常高效的增长和缩短，以适应数据集中数据的动态增加和删除  

## 列表的实例化

C#：
```csharp
    // 数组表
    var arrayList = new ArrayList();
    var anotherArrayList = new List<string>();
    // 链表
    var linkedList = new LinkedList<string>();
```
JAVA：
```java
    // 数组表
    List<String> arrayList = new ArrayList<string>();
    // 链表
    LinkedList<String> linkedList = new LinkedList<string>();
```

## 案例：用户登录服务

参考代码示例：ListTest.LogonTest()  

### 泛型

在计算机科学领域，泛型允许在类声明和方法调用之前，不需要指定数据类型(而是通过占位符)便可进行这些类和方法的定义。

### 自行车路径

保存骑行路径点，有起点和终点，两个方向都可以通行  
可以随时修改路径，及增加路径点  

- 添加路径点，操作代价O(n)  
- 删除路径点，操作代价O(n)  
- 插入路径点，操作代价O(n+i)  

## 双链表

双链表，有n个指针的额外开销(支持反向遍历)，n为列表长度  
添加、插入和删除的操作代价O(1)  

## 查找

- 数组表，已知索引的时候，查找复杂度为O(1)  
- 未排序列表，二分查找复杂度为O(n)  
- 已排序列表，二分查找复杂度为O(logn)  

## 一些指针

内存管理Memory Management
垃圾回收GC，Garbage Colection：C#，JAVA，Swift  
自动引用计数ARC，Automatic Reference Counting： Object-C  
