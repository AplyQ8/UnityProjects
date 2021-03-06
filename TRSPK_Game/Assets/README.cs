/*
                        Отчет по использованным паттернам в лаборотарной работе
                
Все скрипты находится в папке Assets/Scripts, поэтому в пути к классу/ файлу будет опускаться данная часть пути.
Описание паттерна состоит из частей:
1. Путь
2. Область применения паттерна 
3. Смысл использования в лабораторной работе 
4. Дополнительное описание
                
                
                
                
I. Strategy
    1. StrategyPattern
    2. Данный паттерн распространяется на объекты загрузочного меню (выбор формации) и скрипты, описывающие стратегию 
    прикреплены к кнопкам, которые перенаправляют на последующую сцену. Данные стратегии отрисовывают поле во второй сцене 
    (стадия расстановки войск)
    3. Данный паттернам в данном контексте решает проблему размножения сцен конкретной формации. Без использования данного паттерна пришлось 
    бы создавать множество сцен и заново их кастомизировать. Паттерн позволяет же добавить лишь новый класс, реализующий интерфейс IStrategy, который сам отрисует 
    формацию. 
    4. -
II. Singleton
    1. объект во второй сцене TempCardGo
    скрипты, реализующие singleton: CardScripts/ CardScr
    2. Данный паттерн позволяет перемещать карты по полю обращаясь к единственному GameObject: TempCardGo. Скрипт CardScr прикреплен ко всем юнитам 
    и при перемещении юнитов срабатывают eventHandler'ы , которые обращаются к данному объекту
    3. Данный паттерн позволяет сделать более приятный UI для игрока и карты двигаются более "динамически" по полю. 
    4. Допускаю, что данный паттерн не несет огромного смысла в данной лабораторной работе, так как он не разгружает приложение, а предназначен исключительно 
    для более приятного восприятия карт игроком. 
III. ObjectPool
    1. объект во второй сцене objectPooler
    Скрипты находятся в папке: ScriptsForPooler
    2. данный Паттерн позволяет загрузить все объекты юнитов в начале прогрузки сцены 2. Данный паттерн позволяет "жонглировать" юнитами во время 
    расположения юнитов на поле битвы. Скрипт spawner прикреплен на объекты юнитов и позволяет доставать нужных неактивных юнитов из Pool каждый раз, когда ставится 
    юнит на стол. При удалении юнита со стола юнит возвращается в Pool.
    3. Нужно это для того, чтобы нагрузка шла только в самом начале и основная часть
    ресурсов тратилась именно на моменте загрузки, а сам процесс игры не занимал много ресурсов (избегание "лагов").
    4. Данный паттерн было бы более рационально заменить паттерном Fabric, однако данный паттерн, скорее всего, использовал бы метод instantiate, который ест очень
    много ресурсов и скорее всего, это вызывало бы "лаги". Так же стоит учитывать то, что при уничтожении юнитов использовался бы метод destroy, который так же
    крайне затратный как и метод instantiate. 
IV. Adapter
    1. Юнит tumbleweed (перекати-поле)
    Путь: UnitScripts/TumbleWeedAdapter.cs
    2. Данный паттерн реализует ТЗ. Все юниты наследуются от единого интерфейса - IUnit, кроме юнита "перекати поле".
    3. Выполнение требования ТЗ.
    4. -
V. State
    1. KnightStates/ States
    KnightStates/*(все остальные скрипты)
    2. Применяется для отслеживания состояния навешанных "бафов" на юнит "Рыцарь"
    3. Всего существует 4 бафа. для каждогт из них существует по 2 состояния, которые реализуют состояние "баф повешен" и "баф снят". Так же,
    существует начальное состояние которое позволяет надеть любой первый баф. Контроль над состояниями производится в gameObject "Knight". бафы навешиваются из скрипта 
    infantryman (пехотинец).
    4. - 
VI. Subscriber 
    1. MoneyScripts/
    UnitScripts/ActionScript.cs
    2. moneyScripts отвечают за трату валюты в игре. Активно во второй сцене GameObject - Money.
    UnitScripts/ActionsScript Навешен на каждого из юнитов. Здесь паттерн отвечает за вызов функций из скриптов Юнитов (archerScript, KnightScript ect...)
    Каждый юнит в функции OnEnable Подписывается на нужные функции из actionScript. ВО время боя (3 сцена) они вызываются последовательно для каждого юнита, обращаясь к скрипту 
    actionScript каждого юнита. (BattleScripts/BattleScript.cs)
    3. Данный паттерн обоснован тем, что мы во время "боя" не можем напрямую обращаться к скрипту Юнита, т.к. у них разные названия. Для упрощения создается новый скрипт actionScript,
    который хранит делегаты. По данным событиям вызываются нужные функции из скриптов юнитов.
    4. -
VII. Memento (snapshot)
    1. MementoPattern/
    BattleScripts/BattleScript.cs
    MenuScripts/RedoButtonScript.cs
                UndoButtonScript.cs
    2. Вызывается метод сохранения в скрипте battleScript. Каждый раз, когда умирает юнит, поле "сохраняется". Undo и redo книпоки
    (им соотвествуют скрипты) вызываются restoreState из паттерна. 
    3. Данный паттерн реализует требование наличия undo/redo системы.
    4. Реализация паттерна очень похожа на метод Prototype, так как в основе используется метод instantiate (deep copy). В традиционном понимании патерна 
    memento используется shallow copy. Однако, в силу специфики unity shallowCopy игрового поля сделать невозможно, так как это сложная древовидная структура и важно запоминать 
    состояние КАЖДОГО объекта. Поэтому данная реализация паттерна memento мягко говоря не шаблонная. Однако написан он максимально приближенного к шаблонному пониманию патерна. 
VIII. Prototype
    1. UnitScripts/IPrototype.cs
                    MageScr.cs
    2. Использован для реализации механики копирования объектов (особое умение "мага"). Интерфейс IPrototype реализует только те юниты,
    которые по замуслу игры могут быть копированы.  
    3. Реализует ТЗ для спецумения юнита "маг".
    4. Основная проблема в том, что в юнити уже есть готовый метод Instantiate, которые производит deep copy Game-объекта. Чтобы это было больше похоже на паттерн, реализуется интерфейс 
    IPrototype. который имеет единственный метод clone(); Юниты, которые могут быть скопированы реализуют данный интерфейс и внутри данного метода копируют себя же с помощью существующего метода 
    instantiate(); Одновременно с этим, так как данный интерфейс должны реализовывать исключительно классы, описывающие юнит (knightScript, ArcherScript etc...) Метод clone(); так же 
    является методом, который вызывается по событию. Здесь в силу вступает уже описанный ранее (6 пункт) паттерн subscriber. Юнит маг в методе, который описывает спец умение (ultimate();)
    вызывает метод clone(); по событию. 
 */


