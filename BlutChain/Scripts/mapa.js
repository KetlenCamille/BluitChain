<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <script>
        var geocoder;
        var map;
        function initMap() {
            var latlng = new google.maps.LatLng(codeAddress());
        var mapOptions =
            {
            zoom: 15,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    map = new google.maps.Map(document.getElementById('map_canvas'), options);
}
//Recebe as infomações passadas na página AgendamentoDetalhe para gerar o mapa e marcador e transforma em lagitude e longitude para o método Geometry, caso o endereço passado
//por parâmetro esteja correto ele retorna o mapa e marcador, caso dê erro, ele dá mensagem de erro no status
        function codeAddress() {
            var address = document.getElementById('address').value;
            geocoder.geocode({'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
        var marker = new google.maps.Marker(
                        {
            map: map,
        position: results[0].geometry.location
    });
}
                else {
            alert('Mapa não foi gerado com sucesso, erro: ' + status);
        }
    });
}
    </script>

    <script async defer
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCpbsdLaCvNpC0jObCLKvRSH8eFXwuZ5Yk&callback=initMap">
    </script>