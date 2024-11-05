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

 function saveACocktail(cocktailName) {
    const cocktail = { name: cocktailName };
    fetch('/api/Cocktail/SaveCocktail', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cocktail)
    })
    .then(response => {
        if (response.ok) {
            alert(`Cocktail ${cocktailName} saved successfully!`);
        } else {
            alert(`Failed to save ${cocktailName}.`);
        }
    })
    .catch(error => console.error('Error:', error));
}

// Сохранение всего списка в заданном формате (JSON или XML)
function saveCocktails(format) {
    fetch(`/api/Cocktail/output?format=${format}`, {
        method: 'POST'
    })
    .then(response => {
        if (response.ok) {
            alert(`Cocktails saved as ${format.toUpperCase()} successfully!`);
        } else {
            alert(`Failed to save cocktails as ${format.toUpperCase()}.`);
        }
    })
    .catch(error => console.error('Error:', error));
}