jQuery(document).ready(function($) {

  "use strict";

  $(window).on('resize', function() {
    $('#fullscreen-video').css('position', 'static');
    setTimeout(function() {
      $('#fullscreen-video').css('position', 'relative');
    }, 500)
  })

  var iframes = $('.iframe');

  for (var i = 0; i < iframes.length; i++) {
    var iframe = iframes[i];
    $(iframe).attr('width', '100%');
    $(iframe).attr('height', '100%');
    $(iframe).attr('frameborder', '0');
  };


  if($('form#contact_form').length > 0) {
    $('form#contact_form').validate({
      messages: { },
      submitHandler: function(form) {
        $.ajax({
          type: 'POST',
          url: 'send.php',
          data: $(form).serialize(),
          success: function(data) {
            if(data.match(/success/)) {
              $(form).trigger('reset');
              $('#thanks').show().fadeOut(5000);
            }
          }
        });
        return false;
      }
    });
  }

  new WOW().init();

  $('.menu-toggler a').on('click', function(e) {
    e.preventDefault();
    $('header').toggleClass('on');
      $('body').toggleClass('no-overflow');
      $('.menu-toggler a').toggleClass('open');
  });

  var timeout;

  if ($('.images-overlap').length > 0) {
    var waypoint = new Waypoint({
      element: $('.images-overlap'),
      offset: "70%",
      handler: function(direction) {
        if(direction === 'down') {
          // clear the queue removal
          clearTimeout(timeout);
          $('.images-overlap li').addClass('on');
        } else {
          timeout = setTimeout(function() {
            $('.images-overlap li').removeClass('on');
          }, 300);
        }
      }
    });
  }

  if ($('.shapes-overlap').length > 0) {
    var waypoint = new Waypoint({
      element: $('.shapes-overlap'),
      offset: "75%",
      handler: function(direction) {
        if(direction === 'down') {
          // clear the queue removal
          clearTimeout(timeout);
          $('.shapes-overlap li').addClass('on');
        } else {
          timeout = setTimeout(function() {
            $('.shapes-overlap li').removeClass('on');
          }, 300);
        }
      }
    });
  }

  if ($('.case-study').length > 0) {
    var waypoint = new Waypoint({
      element: $('.case-study'),
      offset: "75%",
      handler: function(direction) {
        if(direction === 'down') {
          // clear the queue removal
          clearTimeout(timeout);
          $('.case-study img').addClass('on');
        } else {
          timeout = setTimeout(function() {
            $('.case-study img').removeClass('on');
          }, 300);
        }
      }
    });
  }


  $(".milestone").appear(function() {
    $('.number', $(this)).countTo({
      speed: 1400
    });
  });

  $(document).scroll(function() {
    var windowHeight = $(window).height();
    var windowHalfHeight = windowHeight / 2;
    var windowScrollTop = $(document).scrollTop();

  });

  $(document).scroll(function() {
    var windowHeight = $(window).height();
    var windowHalfHeight = windowHeight / 2;
    var windowScrollTop = $(document).scrollTop();

  });

  if ($('#slides').length > 0) {
    $('#slides').on('init.slides', function() {
      var that = this;
      setTimeout(function() {
        $('.slides-container', that).children().eq(0).addClass('active');
      }, 300);
    });

    $('#slides').superslides({
      animation: 'slide',
      hashchange: false,
      autoplay: false
    });

    $('#slides').on('animated.slides', function() {
      $('.slides-container', this).children().removeClass('active');

      var index = $(this).superslides('current');
      var that = this;

      setTimeout(function() {
        $('.slides-container', that).children().eq(index).addClass('active');
      }, 300);

    });
  }

  if ($('.slides').length > 0) {
    $('.slides').slick({
      autoplay: false,
      pauseOnHover: false,
      dots: true,
      speed: 1000,
      arrows: false
    });
  }


});