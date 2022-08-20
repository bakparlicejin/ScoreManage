项目说明：
1.项目采用标准三层架构；
  顶层 应用UI层  ScoreManager.WebApp
  服务层接口  ScoreManager.ServiceInterface
  服务层实现  ScoreManager.ServiceImpl
  

以上是三层结构，从上到下调用，按照规范层与层之间不可逆向调用，同一实现层之间可相互调用

通用工具  ScoreManager.Common  提供通用方法比如各类helper
实体		 ScoreManager.Model   映射实际数据库表

2. 项目采用国产ORM SqlSugar
  CodeFirstConsole 项目是通过代码来生成数据库的控制台项目 （你必须先写好实体类）
  DBFirstConsole   项目是通过数据库来生成实体模型的项目（你必须先在数据库建好表）
  使用方法：
  1.修改代码中的数据库连接字符串（我连的本机，你也可以在本机安装Oracle服务端）
  2.右键项目设为启动项目启动，如果是codefirst 那么数据库中的表就会生成 如果是DBFirstConsole 那么项目中的实体就会生成
注意：操作中需要先看下代码，看看和你自己的配置是不是一样，如果实在操作不下来，可以忽略这个项目，手动建库建实体吧。其实项目中实体我已经生成过了 就是ScoreManager.Model这个项目。这个
说明只是为了说明这两个项目是干什么用的，其实和本项目关联不大；

应用层说明：
1. 项目采用 Net5 框架开发 使用了依赖注入的方式来注入服务，所以标准三层的服务需要注册服务 示例中已加入了一个 UserService 的注入方式，其他表可以类似加入；
2. startup 类作为项目主要的配置启动类，如果不明白不要在Configure 方法中加中间件，除非你明白你在做什么；
3. wwwroot 是项目的静态文件，在vs中加入后不会立即生效，需要手动拷贝到项目的根目录下的同名文件，结构保持一致；


相关资料：
SqlSugar：https://www.donet5.com/home/Doc?typeId=1180
LayUI：https://layuion.com/docs/



