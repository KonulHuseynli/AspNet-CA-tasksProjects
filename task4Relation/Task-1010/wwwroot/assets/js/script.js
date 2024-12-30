$(document).ready(function () {

  function SelectingBullet() {
    //#region showing-selected-bullet
    $(document).on('click', '.bullet', function () {
      $('.bullet').removeClass('selected');
      $(this).addClass('selected');
    })
    //#endregion showing-selected-bullet
  }
  SelectingBullet()


  function ShowingBanners() {

    //#region showing-banner-page-1
    $(document).on('click', '.bullet-1', () => {
      $('.banner-page-1').removeClass('second-banner third-banner').addClass('first-banner')
      $('.banner-page-2').removeClass('first-banner third-banner').addClass('second-banner')
      $('.banner-page-3').removeClass('first-banner second-banner').addClass('third-banner')
    })
    //#endregion showing-banner-page-1


    //#region showing-banner-page-2 
    $(document).on('click', '.bullet-2', () => {
      $('.banner-page-2').removeClass('second-banner third-banner').addClass('first-banner')
      $('.banner-page-1').removeClass('first-banner third-banner').addClass('second-banner')
      $('.banner-page-3').removeClass('first-banner second-banner').addClass('third-banner')
    })
    //#endregion showing-banner-page-2 



    //#region  showing-banner-page-3
    $(document).on('click', '.bullet-3', () => {
      $('.banner-page-3').removeClass('second-banner third-banner').addClass('first-banner')
      $('.banner-page-2').removeClass('first-banner third-banner').addClass('second-banner')
      $('.banner-page-1').removeClass('first-banner second-banner').addClass('third-banner')
    })
    //#endregion showing-banner-page-3


    //#region showing banner-pages with setInterval
    let customIndex = 1;
    window.setInterval(() => {

      if (customIndex > 2) {
        customIndex = 0;
      }

      //#region showing-banner-page-1 with SetInterval
      if (customIndex == 0) {
        $('.banner-page-1').removeClass('second-banner third-banner').addClass('first-banner')
        $('.banner-page-2').removeClass('first-banner third-banner').addClass('second-banner')
        $('.banner-page-3').removeClass('first-banner second-banner').addClass('third-banner')

        $('.bullet').removeClass('selected');
        $($('.bullet').eq(customIndex)).addClass('selected');
      }
      //#endregion showing-banner-page-1 with SetInterval

      //#region showing-banner-page-2 with SetInterval
      if (customIndex == 1) {
        $('.banner-page-2').removeClass('second-banner third-banner').addClass('first-banner')
        $('.banner-page-1').removeClass('first-banner third-banner').addClass('second-banner')
        $('.banner-page-3').removeClass('first-banner second-banner').addClass('third-banner')

        $('.bullet').removeClass('selected');
        $($('.bullet').eq(customIndex)).addClass('selected');
      }
      //#endregion showing-banner-page-2 with SetInterval

      //#region showing-banner-page-3 with SetInterval
      if (customIndex == 2) {

        $('.banner-page-3').removeClass('second-banner third-banner').addClass('first-banner')
        $('.banner-page-2').removeClass('first-banner third-banner').addClass('second-banner')
        $('.banner-page-1').removeClass('first-banner second-banner').addClass('third-banner')

        $('.bullet').removeClass('selected');
        $($('.bullet').eq(customIndex)).addClass('selected');

      }
      //#endregion showing-banner-page-3 with SetInterval

      customIndex += 1;

    }, 7000)
    //#endregion showing banner-pages with setInterval
  }
  ShowingBanners()


  function TestimonialsSlider() {
    //#region testimonials slider
    $('.comments').slick({
      slidesToShow: 4,
      slidesToScroll: 1,
      centerMode: true,
      focusOnSelect: true,
      // #region Testimonials Slider Responsive
      responsive: [{
          breakpoint: 1200,
          settings: {
            slidesToShow: 3
          }
        },
        {
          breakpoint: 900,
          settings: {
            slidesToShow: 2
          }
        },
        {
          breakpoint: 630,
          settings: {
            slidesToShow: 1
          }
        }
      ]
      // #endregion Testimonials Slider Responsive
    });

    //#endregion testimonials slider
  }
  TestimonialsSlider()


  function SliderLatestNews() {
    //#region latest-news slider
    $('.latest-news-bottom').slick({
      slidesToShow: 3,
      slidesToScroll: 3,
      autoplay: true,
      dots: true,
      arrows: false,
      autoplaySpeed: 1500,
      // #region Latest News Slider Responsive
      responsive: [{
          breakpoint: 1200,
          settings: {
            slidesToShow: 3
          }
        },
        {
          breakpoint: 900,
          settings: {
            slidesToShow: 2,
            slidesToScroll: 2
          }
        },
        {
          breakpoint: 630,
          settings: {
            slidesToShow: 1,
            slidesToScroll: 1
          }
        }
      ]
      // #endregion Latest News Slider Responsive
    });

    // #region AutoPlay Stop to Click on Dots
    $('.slick-dots').on('click', function () {
      $('.autoplay').slick('slickPause');
    });
    // #endregion AutoPlay Stop to Click on Dots
    //#endregion latest-news slider
  }
  SliderLatestNews()


  function NewsTwitterSlider() {
    //#region news-twitter slider
    $('.news-twitter-slider').slick({
      slidesToShow: 1,
      slidesToScroll: 1,
      autoplay: true,
      arrows: false,
      autoplaySpeed: 1500
    });
    //#endregion news-twitter slider
  }
  NewsTwitterSlider()


  function ToggleMobileNav() {
    //#region Open-Close-Mobile-Nav
    $(document).on('click', '.burger-menu', function () {
      $(".mobile-nav").slideToggle()
    })
    //#endregion Open-Close-Mobile-Nav

    //#region accordion
    $("#accordion > li > span").click(function () {
      $(this).closest('li').siblings().find('span').removeClass('active').next('div').slideUp(250);
      $(this).toggleClass("active").next('div').slideToggle(250);
    });
    //#endregion accordion
  }
  ToggleMobileNav()


  function TranferTabTitle() {
    //#region Tranffering Tab Title
    $(document).on('click', '.tab', function () {
      $('.tab').removeClass('active-tab');
      $(this).addClass('active-tab');
      $('.content-title').text($(this).children().eq(0).text())
    })
    //#endregion Tranffering Tab Title
  }
  TranferTabTitle()


  function PricingSlider() {
    //#region Pricing-Slider
    $('.pricing-slider').slick({
      dots: false,
      infinite: true,
      arrows: false,
      slidesToShow: 3,
      slidesToScroll: 1,
      // #region Pricing Slider Responsive
      responsive: [{
          breakpoint: 1200,
          settings: {
            slidesToShow: 2,
            slidesToScroll: 1,
            infinite: true,
            dots: true
          }
        },
        {
          breakpoint: 768,
          settings: {
            slidesToShow: 1,
            slidesToScroll: 1
          }
        }
      ]
      // #endregion Pricing Slider Responsive
    });
    //#endregion Pricing-Slider
  }
  PricingSlider()


  function CloseModal() {
    // #region closing-all-modal
    $(window).on('click', () => {
      let target = $(event.target);
      if (target.is('.modal') || target.is('.modal-container')) {
        $('.modal').removeClass('active-m');
        $('body').css('overflow', 'auto');
      }
    })
    // #endregion closing-all-modal
  }
  CloseModal()


  function OpenCloseVideo() {
    //#region Open-Video
    $(document).on('click', '.play-button', () => {
      $('.modal').addClass('active-m');
      $('body').css('overflow', 'hidden');
    })
    //#endregion Open-Video


    //#region Close-Video
    $(document).on('click', '.quit-x', () => {
      $('.modal').removeClass('active-m');
      $('body').css('overflow', 'auto');
    })

    $('.modal').each(function () {
      var src = $(this).find('iframe').attr('src');

      $(this).on('click', function () {

        $(this).find('iframe').attr('src', '');
        $(this).find('iframe').attr('src', src);

      });
    });
    //#endregion Close-Video
  }
  OpenCloseVideo()


  function ShowingNavScroll() {
    //#region Showing-Nav-On-Scroll
    $(window).scroll(function () {
      var height = $(window).scrollTop();

      if (height > $('header').outerHeight()) {
        $('.header-bottom').addClass('header-fixed');
        $('.st-btn').addClass('st-btn-active');
      } else {
        $('.header-bottom').removeClass('header-fixed');
        $('.st-btn').removeClass('st-btn-active');
      }
    });
    //#endregion Showing-Nav-On-Scroll
  }
  ShowingNavScroll()


  function ScrollTop0() {
    //#region Scroll-Top-Page
    $(document).on('click', '.st-btn', () => {
      window.scrollTo({
        top: 0,
        behavior: 'smooth'
      });
    })
    //#endregion Scroll-Top-Page
  }
  ScrollTop0()

  function ShowingDateAppointment() {
    //#region Showing Date Appointment
    $(document).on('click', '#calendar-body td', function (element) {
      month_year = $(element.target).parent().parent().parent().siblings().eq(0).text();
      for (let i = 1; i < 32; i++) {
        num_text = i.toString();
        if ($(element.target).text().indexOf(`${num_text}`) !== -1) {
          $('.choosing-date').text(`${num_text} ${month_year} `)
          $('#calendar-body td').removeClass('active-date');
          $(element.target).addClass('active-date');
        }
      }
    })
    //#endregion Showing Date Appointment
  }
  ShowingDateAppointment()


  function OpenCloseAppointmentForm() {

    // #region Opening-Closing Appointment Form
    $(document).on('click', '.appointment-hour .button', () => {
      $('.modal').addClass('active-app-form');
    })
    $(window).on('click', () => {
      let target = $(event.target);
      if (target.is('.modal') || target.is('.modal-container')) {
        $('.modal').removeClass('active-app-form');
      }
    })
    // #endregion Opening-Closing Appointment Form
  }
  OpenCloseAppointmentForm()


  function ShowingActiveTrs() {
    //#region schedule active trs
    $('.timetable-select').change(function () {
      $('.timetable-bottom td').removeClass('active-td')

      var value = $(this).val();

      if (value == 'pulmonologist') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'peditrician') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'neurologist') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'geriatrician') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'cardologist') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'dentist') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'prthopaedics') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'cardiologist') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'pediatrician') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'prtjopaedisc') {
        $(`.${value}`).addClass('active-td');
      } else if (value == 'gynecological') {
        $(`.${value}`).addClass('active-td');
      }
    });
    //#endregion schedule active trs
  }
  ShowingActiveTrs()


  function SearchingDoctor() {
    //#region search-doctor on click
    $(document).on("click", '.search-button', function () {
      let searchValue = $('.search-doctor-input').val().toLowerCase().trim();
      $(".doctor-name").filter(function () {
        $(this).parent().parent().parent().toggle($(this).text().toLowerCase().trim().indexOf(searchValue) > -1)
      });
    })
    //#endregion search-doctor on click

    //#region search-doctor on enter press
    $(document).on('keypress', '.search-doctor-input', function (element) {
      if (element.which == 13) {
        let searchValue = $('.search-doctor-input').val().toLowerCase().trim();
        $(".doctor-name").filter(function () {
          $(this).parent().parent().parent().toggle($(this).text().toLowerCase().trim().indexOf(searchValue) > -1)
        });
      }
    });
    //#endregion search-doctor on enter press
    //#endregion search-doctor
  }
  SearchingDoctor()


  function OpenCloseDoctorForm() {
    // #region opening-closing form in find-doctor
    $(document).on('click', '.doctor-item .appointment', () => {
      $('.modal').addClass('active-m');
      $('body').css('overflow', 'hidden');
    })
    $(window).on('click', () => {
      let target = $(event.target);
      if (target.is('.modal') || target.is('.modal-container')) {
        $('.modal').removeClass('active-m');
        $('body').css('overflow', 'auto');
      }
    })
    // #region opening-closing form in find-doctor
  }
  OpenCloseDoctorForm()


  // #region Clinic Slide
  function clinicSlide() {
    // #region Showing Modal
    $(document).on('click', '.gallery-photo', () => {
      $('.modal').addClass('active-m');
      $('body').css('overflow', 'hidden');
    })
    // #endregion Showing Modal

    let sliderIndex = 0;

    // #region Showing Slide First Image
    $(document).on('click', '.plus-overlay-1', () => {
      sliderIndex = 0;
      $('.clinic-slider-element').removeClass('active-slide').addClass('non-active-slide');
      $('.clinic-slider-element').eq(sliderIndex).removeClass('non-active-slide').addClass('active-slide');
    })
    // #endregion Showing Slide First Image


    // #region Showing Slide Second Image
    $(document).on('click', '.plus-overlay-2', () => {
      sliderIndex = 1;
      $('.clinic-slider-element').removeClass('active-slide').addClass('non-active-slide');
      $('.clinic-slider-element').eq(sliderIndex).removeClass('non-active-slide').addClass('active-slide');
    })
    // #endregion Showing Slide Second Image

    // #region Showing Slide Third Image
    $(document).on('click', '.plus-overlay-3', () => {
      sliderIndex = 2;
      $('.clinic-slider-element').removeClass('active-slide').addClass('non-active-slide');
      $('.clinic-slider-element').eq(sliderIndex).removeClass('non-active-slide').addClass('active-slide');
    })
    // #endregion Showing Slide Third Image

    // #region sliding Right DentalClinic Slider
    $(document).on('click', '.right-button', () => {
      sliderIndex += 1;
      if (sliderIndex > 2) {
        sliderIndex = 0;
      }
      $('.clinic-slider-element').removeClass('active-slide').addClass('non-active-slide');
      $('.clinic-slider-element').eq(sliderIndex).removeClass('non-active-slide').addClass('active-slide');
    })
    // #endregion sliding Right DentalClinic Slider

    // #region sliding Left DentalClinic Slider
    $(document).on('click', '.left-button', () => {
      sliderIndex -= 1;
      if (sliderIndex < 0) {
        sliderIndex = 2;
      }
      $('.clinic-slider-element').removeClass('active-slide').addClass('non-active-slide');
      $('.clinic-slider-element').eq(sliderIndex).removeClass('non-active-slide').addClass('active-slide');
    })
    // #endregion sliding Left DentalClinic Slider


    // #region Closing Modal
    $(document).on('click', '.quit', () => {
      $('.modal').removeClass('active-m');
      $('body').css('overflow', 'auto');
    })
    // #endregion Closing Modal
  }
  clinicSlide()
  // #endregion Clinic Slide


  // #region Changing Title of Clinic
  function TitleClinic() {
    $(document).on('click', '.department-ul li', function () {
      $('.department-ul li').removeClass('active-clinic-tab');
      $(this).addClass('active-clinic-tab');

      $('.frame-item .heading').text($(this).text())
      $('.frame-item .changable-subtitle').text($(this).text())
    })
  }
  TitleClinic()
  // #endregion Changing Title of Clinic


  function SearchProduct() {
    //#region search product on click
    $(document).on("click", '.search-product-icon', function () {
      let searchProductValue = $('.search-product-input').val().toLowerCase().trim();
      $(".productt-name").filter(function () {
        $(this).parent().parent().parent().toggle($(this).text().toLowerCase().trim().indexOf(searchProductValue) > -1)
      });
    })
    //#endregion search product on click

    //#region search product on enter press
    $(document).on('keypress', '.search-product-input', function (element) {
      if (element.which == 13) {
        let searchProductValue = $('.search-product-input').val().toLowerCase().trim();
        $(".productt-name").filter(function () {
          $(this).parent().parent().parent().toggle($(this).text().toLowerCase().trim().indexOf(searchProductValue) > -1)
        });
      }
    });
    //#endregion search product on enter press
    //#endregion search product
  }
  SearchProduct()

  // #region OpenMiniCart
  function OpenMiniCart() {
    $(document).on('click', '.basket', () => {
      $('.mini-cart').slideToggle()
    })
  }
  OpenMiniCart()
  // #endregion OpenMiniCart


  // #region TranferringtoCart
  let cartProduct;

  function TranferringtoMiniCart() {
    $(document).on('click', '.add-basket', function () {
      // #region Clearing No-item-text
      $('.no-cart-item').text('')
      // #endregion Clearing No-item-text

      // #region Showing Elements if MiniCart has Item
      $('.total-price').show();
      $('.mini-cart .button').show();
      // #endregion Showing Elements if MiniCart has Item

      // #region This element's add icon change to View Basket
      $(this).addClass('view-basket').removeClass('add-basket').text('View Basket');
      // #endregion This element's add icon change to View Basket

      // #region Choosing elements add to LocalStorage
      $.shoppingcart('add', {
        'id': $(this).parent().parent().parent().attr('id'),
        'image': $(this).parent().parent().css('background-image'),
        'name': $(this).parent().parent().siblings().children().eq(0).text(),
        'price': parseFloat($(this).parent().parent().siblings().children('p').children('.price').text()),
        'count': 1
      });
      // #endregion Choosing elements add to LocalStorage

      // #region Creating items in MiniCart
      cartProduct = $.shoppingcart('getById', $(this).parent().parent().parent().attr('id'));
      let cartProductImage = $(`<div class='cart-product-image' style='background-image: ${$(cartProduct).attr('image')}' ></div>`)
      let cartProductName = $(`<p class='cart-product-name'>${$(cartProduct).attr('name')}</p>`)
      let cartProductPriceQuantity = $(`<span class='cart-product-price-quantity'>${$(cartProduct).attr('count')} ×  $${$(cartProduct).attr('price')}</span>`)
      let cartItem = $(`<li id='${$(this).parent().parent().parent().attr('id')}' class='cart-item'></li>`)
      let cartItemLeft = $(`<div class="cart-item-left"></div>`)
      let cartItemRight = $(`<div class="cart-item-right"></div>`)
      let deleteButton = $(`<i class="far fa-trash-alt delete-btn"></i>`)
      // #endregion Creating items in MiniCart

      // # region Append items to MiniCart
      $(cartItemLeft).append(cartProductImage)
      $(cartItemRight).append(cartProductName)
      $(cartItemRight).append(cartProductPriceQuantity)
      $(cartItem).append(cartItemLeft)
      $(cartItem).append(cartItemRight)
      $(cartItem).append(deleteButton)
      $('.cart-items').append(cartItem)
      // # endregion Append items to MiniCart


      // #region Relation MiniCart
      // #region number over basket
      $('.cart-items-count').text($.shoppingcart('getCount'))
      // #endregion number over basket
      // #region total price in MiniCart
      $('.total-price-number').text($.shoppingcart('getPrice').toFixed(2))
      // #region total price in MiniCart
      // #endregion Relation MiniCart


      ScrollingMiniCart()
      DeletingIteminMiniCart()
    })
  }
  TranferringtoMiniCart()
  // #region TranferringtoCart


  //#region Get Cart Items in Cart
  function GetCartItemsinMiniCart() {

    // #region Showing Elements According to Item Count
    let allCartItems = $.shoppingcart('getAll')
    if ($(allCartItems).length > 0) {
      $('.no-cart-item').text('');
      $('.total-price').show();
      $('.mini-cart .button').show();
    } else {
      $('.total-price').hide()
      $('.mini-cart .button').hide();
    }
    // #endregion Showing Elements According to Item Count


    for (const id in allCartItems)
      if (allCartItems.hasOwnProperty(id)) {
        let cartItm = allCartItems[id];

        $(cartItm).each(function () {

          // #region Creating Items in MiniCart from LocalStorage
          let cartItem = $(`<div id='${$(this).attr('id')}' class='cart-item'></div>`)
          let cartItemLeft = $(`<div class="cart-item-left"></div>`)
          let cartItemRight = $(`<div class="cart-item-right"></div>`)
          let cartProductImage = $(`<div class='cart-product-image' style='background-image: ${$(this).attr('image')}' ></div>`)
          let cartProductName = $(`<p class='cart-product-name'>${$(this).attr('name')}</p>`)
          let cartProductPriceQuantity = $(`<span class='cart-product-price-quantity'>${$(this).attr('count')} ×  $${$(this).attr('price')}</span>`)
          let deleteButton = $(`<i class="far fa-trash-alt delete-btn"></i>`)
          // #endregion Creating Items in MiniCart from LocalStorage

          // #region Append to MiniCart
          $(cartItemLeft).append(cartProductImage)
          $(cartItemRight).append(cartProductName)
          $(cartItemRight).append(cartProductPriceQuantity)
          $(cartItem).append(cartItemLeft)
          $(cartItem).append(cartItemRight)
          $(cartItem).append(deleteButton)
          $('.cart-items').append(cartItem)
          // #region Append to MiniCart


          // #region Relation MiniCart
          // #region number over basket
          $('.cart-items-count').text($.shoppingcart('getCount'))
          // #endregion number over basket
          // #region total price in MiniCart
          $('.total-price-number').text($.shoppingcart('getPrice').toFixed(2))
          // #region total price in MiniCart
          // #endregion Relation MiniCart

          DeletingIteminMiniCart()
          ScrollingMiniCart()
        });
      }

    // #region Showing View Basket Text after Reload Page
    for (let i = 0; i < $('.cart-items .cart-item').length; i++) {
      let activeID = ($('.cart-items .cart-item').eq(i).attr('id'))
      $(`#${activeID}.productt`).children('.product-image').children().children('.add-basket').addClass('view-basket').removeClass('add-basket').text('View Basket');
    }
    // #endregion Showing View Basket Text after Reload Page
  }
  GetCartItemsinMiniCart()
  //#endregion Get Cart Items in Cart

  //  #region DeletingCartItem
  function DeletingIteminMiniCart() {
    $(document).on('click', '.delete-btn', function () {

      // #region Deleting Item from LocalStorage
      $.shoppingcart('remove', {
        'id': $(this).parent().attr('id')
      });
      // #endregion Deleting Item from LocalStorage
      $(this).parent().remove()
      // #region Showing Again Basket Icon
      $(`#${$(this).parent().attr('id')}.productt`).children('.product-image').children().children('.view-basket').addClass('add-basket').removeClass('view-basket').text('').append('<i class="fas fa-shopping-basket"></i>')
      // #endregion Showing Again Basket Icon

      // #region Relation Cart
      $(`#${$(this).parent().attr('id')}.pr`).remove()
      $('.total-price-num').text($.shoppingcart('getPrice').toFixed(2))
      // #endregion Relation Cart

      // #region Relation MiniCart
      // #region number over basket
      $('.cart-items-count').text($.shoppingcart('getCount'))
      // #endregion number over basket
      // #region total price in MiniCart
      $('.total-price-number').text($.shoppingcart('getPrice').toFixed(2))
      // #region total price in MiniCart
      // #endregion Relation MiniCart


      //#region Relation Checkout
      $(`.pro-table tbody #${$(this).parent().attr('id')}.pro`).remove()
      $('.pro-sub-price').text($.shoppingcart('getPrice').toFixed(2))
      $('.pro-total-price').text($.shoppingcart('getPrice').toFixed(2))
      //#endregion Relation Checkout

      ShowingEmptyAlertMiniCart()
      ShowingEmptyAlert()
      ShowingEmptyAlertCheckout()
      ScrollingMiniCart()


    })
  }
  //  #endregion DeletingCartItem

  //  #region ShowProductsinCart
  function GetProductsinCart() {
    // #region Getting All LocalStorage Items
    let allCartItems = $.shoppingcart('getAll')
    // #endregion Getting All LocalStorage Items

    for (const id in allCartItems)
      if (allCartItems.hasOwnProperty(id)) {
        let cartItm = allCartItems[id];

        $(cartItm).each(function () {
          // #region creating products in Cart Page
          let pr = $(`<tr id='${$(this).attr('id')}' class="pr"></tr>`)
          let prImage = $(`<td class="pr-image"><div class="pr-img" style='background-image: ${$(this).attr('image')}'></div></td>`)
          let prName = $(`<td class="pr-name text-left" data-title="Product :">${$(this).attr('name')}</td>`)
          let prPrice = $(`<td class="pr-price" data-title="Price :"><div><span>$</span><span class="pr-price-number">${$(this).attr('price')}</span></div></td>`)
          let prQuantity = $(`<td class="pr-quantity" data-title="Quantity :"> <div class="q-input">
          <input type="number" name="" id="" min="1" value="${$(this).attr('count')}" class="quantity-input">
          <i class="fas fa-minus decrease"></i>
          <i class="fas fa-plus increase"></i>
          </div>
          </td>`)
          let prTotalPrice = $(`<td class="pr-t-price" data-title="Total :"><div><span>$</span><span>${($(this).attr('price')*$(this).attr('count')).toFixed(2)}</span></div></td>`)
          let prRemove = $(`<td class="pr-remove"><i class="fas fa-times x"></i></td>`)
          // #region creating products in Cart Page


          // #region Append to Page
          $(pr).append(prImage)
          $(pr).append(prName)
          $(pr).append(prPrice)
          $(pr).append(prQuantity)
          $(pr).append(prTotalPrice)
          $(pr).append(prRemove)
          $('.product-table tbody').append(pr)
          // #region Append to Page

          // #region Showing Price after Page Load
          $('.total-price-num').text($.shoppingcart('getPrice').toFixed(2))
          // #endregion Showing Price after Page Load


          DeletingProductinCart()
          ShowingEmptyAlert()

        });
      }
  }
  GetProductsinCart()
  //  #endregion ShowProductsinCart


  // #region Delete Product in Cart
  function DeletingProductinCart() {
    $(document).on('click', '.x', function () {
      // #region Deleting Item In Cart Page
      $(this).parent().parent().remove()
      // #endregion Deleting Item In Cart Page

      // #region Deleting Item From LocalStorage
      $.shoppingcart('remove', {
        'id': $(this).parent().parent().attr('id')
      });
      // #endregion Deleting Item From LocalStorage

      // #region Deleting Element from MiniCart
      $(`#${$(this).parent().parent().attr('id')}.cart-item`).remove()
      // #endregion Deleting Element from MiniCart

      // #region Relation MiniCart
      // #region number over basket
      $('.cart-items-count').text($.shoppingcart('getCount'))
      // #endregion number over basket
      // #region total price in MiniCart
      $('.total-price-number').text($.shoppingcart('getPrice').toFixed(2))
      // #region total price in MiniCart
      // #endregion Relation MiniCart

      // #region Showing Elements in MiniCart According to Cart item
      if ($('.cart-item').length == 0) {
        $('.no-cart-item').text('No Products In The Basket')
        $('.total-price').hide()
        $('.mini-cart .button').hide();
      }
      // #region Showing Elements in MiniCart According to Cart item

      // #region Showing Price in Cart Page after Deleting Item 
      $('.total-price-num').text($.shoppingcart('getPrice').toFixed(2))
      // #endregion Showing Price in Cart Page after Deleting Item

      ShowingEmptyAlertMiniCart()
      ScrollingMiniCart()
      ShowingEmptyAlert()
    })
  }
  // #endregion Delete Product in Cart


  function GetProductsinCheckout() {
    // #region Getting All LocalStorage items
    let allCartItems = $.shoppingcart('getAll')
    // #region Getting All LocalStorage items


    for (const id in allCartItems)
      if (allCartItems.hasOwnProperty(id)) {
        let cartItm = allCartItems[id];

        // #region Creating Items in Checkout
        $(cartItm).each(function () {
          let tr = $(`<tr class="pro" id='${$(this).attr('id')}'></tr>`)
          let product_Count = $(`<td>${$(this).attr('name')} × ${$(this).attr('count')}</td>`)
          let proTotalPrice = $(`<td><span>$</span><span>${($(this).attr('price')*$(this).attr('count')).toFixed(2)}</span></td>`)
          $(tr).append(product_Count)
          $(tr).append(proTotalPrice)
          $('.pro-table tbody').append(tr)
        });
      }
    let proSubPrice = $(`<span>$</span><span>${$.shoppingcart('getPrice').toFixed(2)}</span>`)
    let proTotalPrice = $(`<span>$</span><span>${$.shoppingcart('getPrice').toFixed(2)}</span>`)
    // #region Creating Items in Checkout

    // #region Append items to Checkout Page 
    $('.pro-sub-price').append(proSubPrice)
    $('.pro-total-price').append(proTotalPrice)
    // #region Append items to Checkout Page 
    ShowingEmptyAlertCheckout()
  }
  GetProductsinCheckout()


  //  #region ScrollingMiniCart
  function ScrollingMiniCart() {
    if ($('.cart-item').length > 0) {
      $('.mini-cart').addClass('scroll-mini-cart')
    } else {
      $('.mini-cart').removeClass('scroll-mini-cart')
    }
  }
  //  #endregion ScrollingMiniCart


  //  #region ChangeInputValueinCart
  function ChangeInputValue() {
    // #region increasing inputValue in Cart
    $(document).on('click', '.increase', function () {
      var oldValue = parseInt($(this).siblings('.quantity-input').val());
      var newVal = oldValue + 1;
      $(this).siblings('.quantity-input').val(newVal);
      // #region Changing Item Count in LocalStorage when Click Increase Button
      $.shoppingcart('edit', {
        'id': `${$(this).parent().parent().parent().attr('id')}`,
        'count': $(this).siblings('.quantity-input').val()
      })
      // #endregion Changing Item Count in LocalStorage when Click Increase Button
    })
    // #endregion increasing inputValue in Cart


    // #region decreasing inputValue in Cart
    $(document).on('click', '.decrease', function () {
      let min = $(this).siblings('.quantity-input').attr('min');
      var oldValue = parseInt($(this).siblings('.quantity-input').val());
      if (oldValue <= min) {
        var newVal = oldValue;
      } else {
        var newVal = oldValue - 1;
      }
      // #region Changing Item Count in LocalStorage when Click Decrease Button
      $(this).siblings('.quantity-input').val(newVal);
      $.shoppingcart('edit', {
        'id': `${$(this).parent().parent().parent().attr('id')}`,
        'count': $(this).siblings('.quantity-input').val()
      })
      // #endregion Changing Item Count in LocalStorage when Click Decrease Button
    })
    // #region decreasing inputValue in Cart


  }
  ChangeInputValue()
  //  #endregion ChangeInputValueinCart


  // #region UpdatingCart
  function UpdateCart() {
    $(document).on('click', '.update', () => {
      // #region User Include Count Manually 
      $('.quantity-input').each(function () {
        if (!$(this).val() || $(this).val() <= 0) {
          $(this).val(1)
        }
        // #endregion User Include Count Manually 
        // #region Edit LocalStorage Item
        $.shoppingcart('edit', {
          'id': `${$(this).parent().parent().parent().attr('id')}`,
          'count': $(this).val()
        })
        // #endregion Edit LocalStorage Item
      });
      location.reload()
    })
  }
  UpdateCart()
  // #endregion UpdatingCart


  // #region ClearingCart
  function ClearCart() {
    $(document).on('click', '.clear', () => {
      $.shoppingcart('clear');
      location.reload();
    })
  }
  ClearCart()
  // #endregion ClearingCart


  // #region Showing Empty Alert in Cart
  function ShowingEmptyAlert() {
    if ($('.pr').length == 0) {
      $('.empty-cart-alert').show()
      $('.return-btn').css('display', 'inline-block')
      $('.pr-form').hide()
    } else {
      $('.empty-cart-alert').hide()
      $('.return-btn').css('display', 'none')
      $('.pr-form').show()
    }
  }
  // #endregion Showing Empty Alert in Cart


  // #region Showing Empty Alert in Mini Cart 
  function ShowingEmptyAlertMiniCart() {
    if ($('.cart-item').length == 0) {
      $('.no-cart-item').text('No Products In The Basket')
      $('.total-price').hide()
      $('.mini-cart .button').hide();
    }
  }
  // #endregion Showing Empty Alert in Mini Cart 

  // #region Showing Empty Alert in Checkout
  function ShowingEmptyAlertCheckout() {
    if ($('.cart-item').length == 0) {
      $('.checkout-content').hide()
      $('.checkout-alert').show()
    } else {
      $('.checkout-alert').hide()
    }
  }
  // #endregion Showing Empty Alert in Checkout


  // #region AOS animation
  AOS.init({
    offset: 100,
    duration: 2000,
    easing: "ease-out-quad",
    once: !0
  });
  window.addEventListener('load', AOS.refresh);
  // #endregion AOS animation
});