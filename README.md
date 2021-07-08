# Game02

## 1.整体框架
使用Do Tween和Animation实现金币飞舞的效果。
使用Scroll Rect和Grid Layout Group实现排列页面和上下滑动的功能。


## 2.目录结构 
````
｜——DOTween                          #DoTween插件  
｜  
｜——Scripts   
｜   |__DataManagers  
｜   |  |__BuyManager            #更新金币、钻石数据     
｜   |  |__PlayerInfo                #玩家金币、钻石信息  
｜   |     
｜   |__UIControl    
｜      ｜__BuyUIButtonFunction      #购买窗口相关   
｜      ｜__CoinEffectControl        #显示金币飞舞特效控制  
｜      ｜__EnterUIControl           #初始界面按钮  
｜     
｜——Resources    
｜  ｜__Prefabs                      #预制体模型    
｜
````

## 3.代码逻辑分层

代码逻辑分为三层，分别是main、controller、model。 mian层控制运行流程，controller控制界面的现实隐藏和商品信息的显示以及购买情况，model层显示界面具体信息。程序有四个类，EnterUIControl负责控制主界面显示，BuyUIButtonFunction负责显示购买标记，DataManager负责更新购买后的金币和钻石数据，它的相应方法函数在BuyUIButtonFunction被调用

## 4.存储设计

卡片UI和购买窗口放在一起做成预制体以供使用，另有一个金币预制体在做金币飞舞效果时使用，卡片预制体可以根据需要修改显示的内容。

## 5.接口设计

玩家购买次数设置为静态拱其它脚本直接调用。

## 6.todo

后续优化：玩家购买确定窗口跟点击次数绑定，直接多次点击购买按钮会出现多个窗口，另外在金币飞舞特效没有播放完成时没有限制禁止点击购买按钮，后续可以限制这些场景的按钮点击。货币不足以购买时是在控制台用文字提示，后续可以加上窗口提醒。
