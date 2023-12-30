# 集合：不包含重复项的数据集

集合set，不包含重复项的(相似元素)简单数据集，能提供强大的数据分析能力  
一种由无特定顺序的不同对象或值所构成的数据集  

## 集合论

以集合论set theory为基础得数据结构

- 并集union。A ∪ B  
- 交集intersection。A ∩ B  
- 对称差difference。A ∆ B  
- 补集compliment/relative compliment。A \ B  
- 子集subset。A ⊆ B或A ⊂ B (inclusion包含于)  
- 超集superset。A ⊇ B或A ⊃ B (containment包含)  

[更多集合符号的说明](https://www.rapidtables.org/zh-CN/math/symbols/Set_Symbols.html)  

## 初始化

C#：
```csharp
    HashSet<string> colors = new HashSet<string>();
    colors.Add("green");
    Console.WriteLine($"{colors.Count}");
    colors.Add("yellow");
    Console.WriteLine($"{colors.Count}");
    colors.Add("red");
    Console.WriteLine($"{colors.Count}");
    colors.Add("red");
    Console.WriteLine($"{colors.Count}");
    colors.Add("blue");
    Console.WriteLine($"{colors.Count}");
```

### 集合的操作

- Add增加。插入操作，可以防止插入重复对象。返回布尔值，表示是否插入成功，操作代价O(n)  
- remove删除。移除操作，从集合中删除一个已有对象。返回布尔值，表示是否删除成功，操作代价O(n)  
- capacity容量。可以根据需要动态调整集合大小。返回当前集合定义的限定大小，操作代价O(1)  
- union并集。返回一个新集合，并不改变原来的两个集合。操作代价O(m+n)  
- intersection交集。返回两个或多个集合共有元素的新集合。任意两个集合的交集操作代价为O(m*n)；如果多于2个，操作代价则变为(n-1)*O(L)，n为集合数量，L为最大的一个集合的长度(代价较高，应避免)  
- difference对称差。交集的逆运算。返回每个集合独有元素的新集合。操作代价O(m)，m为两个集合中的较小的长度值  
- subset子集。判断一个集合A是否包含于另一个集合B，返回布尔值。操作代价O(m)，m为集合A的大小  
- count计数。返回特定集合的基数cardinality，是描述集合包含元素数量的术语。操作代价O(1)  
- isEmpty判断集合是否为空。表示集合是否不包含任何元素。如果集合容量制定了一个限定值，还会提供isFull操作。操作代价均为O(1)  

## 案例学习：用户登录服务

参考代码示例：SetTest.LogonTest()  

### 代码锲约

声明接口interface来实现

## 案例学习：音乐播放列表

参考代码示例：SetTest.PlaylistSet()  

## 高级话题

### 散列表集合

常用于非顺序集合。普通应用中的大多数集合，都是散列表集合  
散列表集合与字典的操作代价相当，搜索、插入及删除代价均为O(n)  

### 树集合

通常基于二叉查找树，或其他结构  
通常进行平均意义上的高效查找，对于检查的每一个节点，都可将其分支从剩余查找模式中删除  
最坏操作代价O(n)，但很少出现这种情况  

### 数组集合

经过适当组织的数组集合中，数组可以更高效实现集合的子集、并集、交集和对称差操作  
