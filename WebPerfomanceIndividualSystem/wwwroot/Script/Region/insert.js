(() => {
    const form = document.querySelector('.upsert-form');
    form.addEventListener('submit', el => {
        el.preventDefault();

        const form = new FormData(el.currentTarget);
        if (!form.get('city')) alert('Kolom city isi boy!');
        else {
            // Unggah data
            const url = 'https://localhost:7131';
            const poinAkhir = '/api/v1/region';
            const req = new XMLHttpRequest();
            req.open('POST', url + poinAkhir);
            req.setRequestHeader('Content-Type', 'application/json');
            req.send(JSON.stringify({
                city: form.get('city'),
                remark: form.get('remark')
            }));
            req.onload = () => location.href = '/region';
        }
    });
})();