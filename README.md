# Требования к проекту "Магазин цифровых ключей игр"

В проекте предусмотрены два типа пользователей: покупатель и модератор, продавцом является сама площадка. Пользователь, не авторизованный в системе, имеет право просмотра всех предложений магазина. Покупатель может как приобретать ключи, так и просматривать историю своих покупок. Модератор имеет право создавать, изменять и удалять товары.

## Требуемая функциональность

1. **Регистрация пользователя.** Основная ссылка перехода на форму регистрации доступна неавторизованному пользователю на любой странице, а дополнительная отображается ему при попытке приобрести товар. Форма регистрации содержит поля ввода имени пользователя (никнейма), даты рождения, почты и пароля. Учетная запись создаётся с помощью подтверждения по электронной почте.
2. **Авторизация и деавторизация пользователя.** Основная ссылка перехода на форму входа доступна неавторизованному пользователю на любой странице, а дополнительная отображается ему при попытке приобрести товар. При входе в систему требуется ввести электронную почту и пароль от учетной записи. При выходе из системы авторизованному пользователю требуется нажать на соответствующую ссылку на любой странице.
3. **(INDEX) просмотр списка товаров.** В проекте поиск товара осуществляется как по его названию, так и по фильтрам: жанр, год издания, цена, тип издания и площадка для активации (Stream, EA app, Epic Games Store и другие).*
5. **(CREATE) создание товара.** Модератор может создать новый товар, заполнив следующие поля: название, жанр, год издания, цена, тип издания и площадка для активации.*
6. **(READ) просмотр деталей товара.** Любой пользователь может просматривать характеристики товара.
7. **(UPDATE) редактирование товара.** Модератор может изменить характеристики любого товара.
8. **(DELETE) удаление товара.** Модератор может удалить любой товар.

## Модель базы данных
![image](https://github.com/user-attachments/assets/8b208256-c016-4f03-ad50-db76d9e99479)
