# <p align="center">Проект представляет серверную сторону *Блога*. </p> 

Проект написан на **ASP NET CORE 5.0**. Шаблон - **WEB API**. Доступ к функционалу осуществляется при помощи **Swagger**. СУБД - **MS SQL Server** (local). ORM - **Entity Framework Core**.

## Как работать с сайтом

После копирования проекта к себе на устройство, вам необходимо выполнить *миграции* для создания Базы данных.</br> Откройте решения проекта в *Visual Studio*. Далее необходимо открыть _Консоль диспетчера пакетов_ и выполнить ряд команд:</br>
``` 
Add-Migration NameOfMigration
```
Далее:
```
Update-Database
```
Далее можно запускать проект.
> Более подробную информацию о миграциях вы можете узнать здесь: **https://learn.microsoft.com/ru-ru/ef/core/managing-schemas/migrations/?tabs=vs**.

## Функционал сайта

### Admin functions
1. `/Admin/GetAllPosts` - *получить все посты всех пользователей*
2. `/Admin/DeletePost` - *удалить пост*
3. `/Admin/UpdatePost` - *обновить пост*
4. `/Admin/DeleteComment` - *удалить комментарий*
5. `/Admin/GetAllCommentsByUserId` - *получить все комментарии заданного пользователя*

### Comment functions
1. `/Comment/AddMainComment` - *написать главный комментарий под пост*
2. `/Comment/AddSubComment` - *написать сабкомментарий под главный комментарий*
3. `/Comment/DeleteMainComment` - *удалить главный комментарий под подстом*
4. `/Comment/DeleteSubComment` - *удалить сабкомментарий под главным комментарием*
5. `/Comment/UpdateMainComment` - *обновить главный комментарий под постом*
6. `/Comment/UpdateSubComment` - *обновить сабкомментарий под главным комментарием*

### Post functions
1. `/Post/AddPost` - *добавить пост*
2. `/Post/GetAllYourPosts` - *получить все свои посты*
3. `/Post/GetAllYourPostsWithComments` - *получить все свои посты с комментариями*
4. `/Post/GetPostWithCommentsById` - *получить заданный пост с комментариями*
5. `/Post/GetAllPostsByUserId` - *получить все посты заданного пользователя*
6. `/Post/DeleteYourPostById` - *удалить свой пост*
7. `/Post/UpdatePost` - *обновить пост*

### User functions
1. `/User/Logout` - *Выйти с аккаунта*
2. `/User/Login` - *Войти в аккаунт*
3. `/User/Register` - *Зарегистрировать аккаунт*
4. `/User/GetCurrentUserInformation` - *Получить информацию о пользователе*

### Аккаунт админа

*Логин* - `admin`

*Пароль* - `password`