# SiHan.Libs.Utils
## 介绍

该库提供C#常用工具类，基于netstandard2.0，可以在ASP.NET Core和winform中使用。

## 安装

```
PM> Install-Package SiHan.Libs.Utils
```

## 工具集

### 文件工具

FileHelper：使用UTF-8编码来从文件中读取文本内容、或写入文本内容。

### 加密工具

ITextEncryptor：文本加密接口

AesEncryptor：AES加密器。

Md5Encryptor：MD5加盐

### 字符串工具

Base64Helper：使用UTF-8实现BASE64的编码与解码

FormatHelper：提供日期、布尔值、数字的文字格式化

GuidHelper：生成带序列的GUID值

SNGenerator：序列号生成器

SortHelper：排序字符串的处理类

StringMatchHelper：常用正则表达式匹配检测

### 日期工具

DateTimeHelper：获取日期范围等功能的帮助类

### 站点地图

```c#
Sitemap sitemap = new Sitemap();
sitemap.Add(new SitemapNode {Url = "http://www.google.com"});
sitemap.Add(new SitemapNode {Url = "http://www.bing.com"});
string xml = sitemap.GetSitemapDocument();
```

### 分页工具

Pager：分页核心类，通过行总数、分页尺寸生成页码等信息。

PagingModel：分页模型类，为ASP.NET Core视图模型提供分页基类。

PagingResult：分页结果，为业务层提供保存分页数据的基类。

### 扩展类

为Regex提供扩展方法GetMatchString()，用于获取匹配文本。

