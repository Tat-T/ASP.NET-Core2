 // Динамическое добавление заголовков таблицы
 const headers = ['Название', 'Состав', 'Загрузка'];
 const headerRow = document.getElementById('tableHeaders');
 
 headerRow.innerHTML = headers.map(header => `<th>${header}</th>`).join('');

 // Пример данных для таблицы
 const cocktails = [
     { name: 'Маргарита', composition: 'Текила, Лаймовый сок, Куантро или трипл-сек, соль для ободка бокала'},
     { name: 'Мохито', composition: 'Белый ром, сок лайма, сахар, листья мяты, газированная вода' },
     { name: 'Пина Колада', composition: 'Светлый ром, кокосовое молоко, ананасовый сок' },
 ];

 const cocktailTable = document.getElementById('cocktailTable');
 cocktailTable.innerHTML = cocktails.map(cocktail => `
     <tr>
         <td>${cocktail.name}</td>
         <td>${cocktail.composition}</td>
         <td><button class="btn btn-primary" onclick="saveCocktail('${cocktail.name}')">Загрузить в файл</button></td>
     </tr>
 `).join('');

 function saveCocktail(cocktailName) {
     console.log(`Saving ${cocktailName}`);
 }

 function saveCocktails(format) {
     console.log(`Saving all cocktails as ${format}`);
 }

 loadCocktails();
