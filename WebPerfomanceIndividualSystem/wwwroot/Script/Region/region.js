(() => {
    const regionTable = document.querySelector("[id=region-table]");

    function fetchData(cityName) {
        // Unduh data
        const url = 'https://localhost:7131';
        const poinAkhir = '/api/v1/region/' + cityName;
        const req = new XMLHttpRequest();
        req.open('GET', url + poinAkhir);
        req.send();

        // Fungsi tombol
        function fUpdate() { }
        function fDelete() { }
        function fSalesman() { }

        // Muat data
        req.onload = res => {
            const data = JSON.parse(res.target.response);

            data.forEach(region => {
                const tr = document.createElement('tr');

                const updateButton = document.createElement('button');
                updateButton.innerHTML = 'Edit';
                updateButton.setAttribute('class', 'blue-button update-button');
                updateButton.addEventListener('click', fUpdate);

                const deleteButton = document.createElement('button');
                deleteButton.innerHTML = 'Delete';
                deleteButton.setAttribute('class', 'blue-button delete-button');
                deleteButton.addEventListener('click', fDelete);

                const salesmanButton = document.createElement('button');
                salesmanButton.innerHTML = 'Salesman';
                salesmanButton.setAttribute('class', 'blue-button salesman-button');
                salesmanButton.addEventListener('click', fSalesman);

                // 1
                const td = document.createElement('td');
                td.style.display = 'flex';
                td.style.gap = '0.25rem';
                td.appendChild(updateButton);
                td.appendChild(deleteButton);
                td.appendChild(salesmanButton);
                tr.appendChild(td);

                // 2
                const tdCity = document.createElement('td');
                tdCity.innerHTML = region.city;
                tr.appendChild(tdCity);

                // 3
                const tdRemark = document.createElement('td');
                tdRemark.innerHTML = region.remark;
                tr.appendChild(tdRemark);

                regionTable.appendChild(tr);
            });
        };
    } fetchData('');

    // Filter
    const form = document.querySelector('.filter');
    form.addEventListener('submit', el => {
        el.preventDefault();
        regionTable.innerHTML = '';
        const form = new FormData(el.currentTarget);
        fetchData(form.get('city'));
    })
})()