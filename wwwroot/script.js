const headers = ['Название', 'Состав', 'Загрузка'];
const headerRow = document.getElementById('tableHeaders');

headerRow.innerHTML = headers.map(header => `<th>${header}</th>`).join('');

// Пример данных для таблицы
const cocktails = [
    { name: 'Маргарита', composition: 'Текила, Лаймовый сок, Куантро или трипл-сек, соль для ободка бокала' },
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
    const cocktail = cocktails.find(c => c.name === cocktailName); // Находим полную информацию о коктейле
    if (!cocktail) {
        alert('Cocktail not found!');
        return;
    }
    
    fetch('/api/Cocktail/SaveCocktail', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cocktail) // Отправляем полную информацию о коктейле
    })
    .then(response => {
        if (response.ok) {
            alert(`Коктейль "${cocktailName}" успешно сохранен!`);
        } else {
            alert(`Не удалось сохранить коктейль "${cocktailName}".`);
        }
    })
}

// Сохранение всего списка в заданном формате (JSON или XML)
function saveCocktails(format) {
    fetch(`/api/Cocktail/output?format=${format}`, {
        method: 'POST'
    })
    .then(response => {
        if (response.ok) {
            alert(`Коктейли успешно сохранены в формате ${format.toUpperCase()}!`);
        } else {
            alert(`Не удалось сохранить коктейли в формате ${format.toUpperCase()}.`);
        }
    })
    .catch(error => console.error('Ошибка:', error));
}
