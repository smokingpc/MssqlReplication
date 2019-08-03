# MSSQL Server Replication簡易說明與練習


[簡介]

MSSQL Server Replication是兩台資料庫自動同步的功能，不管在異地備援或是 Redundant DB 之類的功能需求都很有用。因為工作上正好用到，需要教團隊如何使用，就順手做了這個 Project。

MSSQL Server Replication適用於MSSQL Express以及MSSQL正式版。大家可以用免錢的MSSQL Express來練習，設定跟正式版一模一樣。

DBWriteTool是測試DB Replication的簡單小工具。可以利用這個小工具去觀察DB Replication的一些行為特徵，例如執行到一半兩台資料庫斷線，兩邊的資料表有什麼不同？或是兩邊各自寫了幾筆資料後突然恢復連線，資料庫同步又會出什麼問題？

[使用說明]
1.  動手前請先閱讀doc目錄下的PPT檔

2.  DBWriteTool這工具支援MSSQL 的TCP與ShareMemory連線。用TCP連線記得先去SQL Server的Configuration Manager打開TCP Protocol。

    如果想用ShareMemory連線，則DBWriteTool這支測試工具必須在MSSQL運行的電腦上執行。

3.  安裝好MSSQL Server後先把db_script目錄下的Script在MSSQL跑一次，它會建立好對應的DB以及資料庫登入帳號。

4.  在兩台不同的DB Server上執行 DBWriteTool ，模擬資料庫讀取與寫入的工作。模擬中你可以隨意亂搞網路(例如拔網路線或是關閉網卡)，來仿效真實環境的斷線狀況，以觀察DB Replication會有什麼行為與限制。

這樣能夠確實的了解Replication的行為，而且不同資料庫(如MySQL或PostgreSQL)的Replication功能原理其實差不多，詳細搞懂一個之後想去學其他資料庫的功能會輕鬆很多。

 **_SmokingPC_** 
