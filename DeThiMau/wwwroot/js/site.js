(function ($) {
    $(function () {
        $(document).on('click', '.category-link', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.get(window.hangHoaTheoLoaiUrl, { id: id })
                .done(function (html) { $('#product-list').html(html); })
                .fail(function () { $('#product-list').html('<p>Không tải được danh sách hàng hóa. Vui lòng thử lại.</p>'); });
            $('.menu li').removeClass('active');
            $(this).parent().addClass('active');
        });

        $(document).on('input', '#search-product', function () {
            var keyword = ($(this).val() || '').toLowerCase();
            $('#product-list .product-card').each(function () {
                var text = $(this).text().toLowerCase();
                $(this).toggle(text.indexOf(keyword) >= 0);
            });
        });
    });
})(jQuery);
