Nuget های استفاده شده  در برنامه  
Install-Package MediatR    
Install-Package FluentResults    
Install-Package FluentValidation    
Install-Package Microsoft.EntityFrameworkCore   
Install-Package Microsoft.EntityFrameworkCore.InMemory   
Install-Package Microsoft.EntityFrameworkCore.SqlServer   
Install-Package FluentValidation.AspNetCore   
Install-Package Moq MediatR.Extensions.Microsoft.DependencyInjection   
AutoMapper.Extensions.Microsoft.DependencyInjection   
Install-Package FluentValidation.AspNetCore   
Install-Package AutoMapper   

از sql server استفاده کردم اگر می خواهید جدول ها در دیتابس ساختن بشن حتما رمز sa خود را به 1234512345 تغییر بدید. یا به فایل appsettings.json برید و رمز sa را به دلخواه خود عوض کنید

دو تا UnitOfWork پیاده سازی کردم یکی برای Query یکی هم برای update delete insert  و براحتی میتوان چند نوع ORM داشت 

از Reflaction استفاده کردم چون که توابع در لایه OvetimePolicies  متغیر و نامشخص  می باشند
