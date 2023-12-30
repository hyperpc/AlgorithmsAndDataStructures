# 字典：关键字数据集

字典dictionary，抽象的数据结构  
由键值对构成的数据集，每个键只在该数据集中出现一次  
又称为关联数组associative array，或映射map

- 用于散列字典(哈希字典，hash table-based dictionary)的散列映射(哈希映射hash map)  
- 用于查找树字典(search tree-based dictionary)的树映射(tree map)

常见操作：增加、更新、获取、删除，计数、重分配、置入和判断当前字典是否已存在指定键  

设计良好的字典中，新建、修改或获取操作的最低代价可为O(1)  

## 初始化

C#：
```csharp
    Dictionary<string, int> dict = new Dictionary<string, int>();
    dict.Add("green", 1);
    dict.Add("yellow", 2);
    dict.Add("red", 3);
    dict.Add("blue", 4);
    dict.Remove("blue");
    Console.WriteLine($"{dict["red"]}"); // 3
```

### 字典的操作

- 增加 add：O(1)  
- 获取 get：O(1)  
- 更新 update：O(1)  
- 删除 remove：O(1)  
- 判断是否存在指定键 contain：O(n)  
- 计数 count：O(1)  
- 重分配 reassian：O(1)  
- 置入 set：O(1)  

## 案例学习：游戏代币统计

参考代码示例：DictTest.PointsDictionary()  

## 高级话题

散列表字典和查找树字典，结构相近，并公用一些方法和功能；但内部工作方式和应用场景却各异  

### 散列表字典

基于散列表(hash table based)的关联数组
默认的散列表字典，设计良好的情况下，复杂度为O(1)  
缺点：有制造冲突的可能(两个健映射到同一个索引)。需要提供冲突解决策略

### 查找树字典

基于查找树(search tree based)的关联数组  
适用通过值的某些准则或特点堆健和值进行排序得应用  
还可根据健或值的数据类型进行定制，以构建更高效运行的字典，  
此时，查找树的基础操作代价更高  
