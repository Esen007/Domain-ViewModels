ViewModel және валидация лабораториясы
Understanding
Razor Pages емес, workspace-тағы ASP.NET Core MVC шаблонына сәйкес жаңа тауарды тіркеу мысалын толық іске асыру керек: Domain Model мен ViewModel-ді бөлу, Data Annotations, серверлік ModelState, клиенттік Unobtrusive Validation және Razor хабарламалары.

Assumptions
Практикалық мысал ретінде пайдаланушы профилі емес, жаңа тауарды тіркеу таңдалады.
Қолданыстағы MVC құрылымы сақталады; деректер қорын қоспай, POST нәтижесін demo ретінде көрсету жеткілікті.
Барлық атрибуттардан бөлек, өздік жұмысқа арналған IValidatableObject тексеруі де ViewModel ішінде көрсетіледі.
Approach
Models ішінде persistence/domain объектісін және ViewModels ішінде form-ға арналған DTO-ны бөлек құрамын. ViewModel барлық сұралған Data Annotations атрибуттарын қолданады және IValidatableObject арқылы баға/жеңілдікке қатысты cross-field ережені тексереді. HomeController GET/POST әрекеттерімен ModelState-ті тексеріп, демонстрациялық қолмен қате қосады.

Index.cshtml форма, field-level validation, summary және validation scripts partial арқылы көрсетіледі. Қате енгізілгенде модель қайта көрсетіледі, дұрыс енгізілгенде хабарлама шығарылады.

Key Files
Models/Product.cs — Domain Model.
ViewModels/ProductCreateViewModel.cs — validation-ы бар ViewModel.
Controllers/HomeController.cs — GET/POST және ModelState басқаруы.
Views/Home/Index.cshtml — форма және қате хабарламалары.
Risks & Open Questions
Жоба атауы кириллица болғанымен, namespace csproj-та берілген RootNamespace арқылы тұрақты қолданылады.
Нақты сақтау қабаты жоқ, сондықтан лабораториялық мақсатта POST сақтау орнына success message көрсетіледі.
Steps
Domain Model файлын қосу
Валидациясы бар ViewModel файлын қосу
Controller әрекеттерін іске асыру
Razor формасын және validation хабарламаларын қосу
Жобаны құрастырып тексеру
