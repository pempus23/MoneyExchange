jQuery( document ).ready( function( $ ){

	// Intro size setup

	setupIntro(); // On ready, resize intro

	$( window ).resize( function() { setupIntro(); } ); // On resize

	function setupIntro() {
		var infoBox = $('.info' );
		var titleBox = $( '.info').find('.container');
		$( '.info' ).find( '.container' ).css( 'top', ( ( infoBox.height() - titleBox.height() - 20 ) / 2) + 'px' );
	}

	// Skill pie charts

	setupPie(); // On ready, initialize pies

	function setupPie() {
		$( '.skill-pie' ).easyPieChart( {
			barColor: '#f08b65',
			trackColor: '#cccccc',
			scaleColor: false,
			lineWidth: 5,
			size: 120
		} );
	}

	// Making navigation sticky on scroll

	$( '#nav' ).sticky( { topSpacing:0 } );

	$( '#nav ul' ).onePageNav( { scrollSpeed: 400 } );

	$(window).scroll(function(){
		if($(window).scrollTop() < $(window).height()/2) {
			$('#nav').find('li').removeClass('current');
		}
	});

	// Portfolio sorter initialization
	$( '.projects' ).mixitup( {
		targetSelector: '.project',	// Class required on each portfolio item
		filterSelector: '.filter', // Class required on each filter link
		effects: ['rotateZ'],
		easing: 'snap'
	} );

	// Portfolio items zoom / popover
	$( '.image-popup' ).magnificPopup( {type: 'image' } );

	$( '.video-popup' ).magnificPopup( {type: 'iframe' } ); // Supports YouTube, Vimeo and Google Maps links.

	$('.gallery').each(function() { // the containers for all your galleries should have the class gallery
		$(this).magnificPopup({
			delegate: 'a', // the container for each your gallery items
			type: 'image',
			gallery:{enabled:true}
		});
	}); 

	// Portfolio item :hover overlay
	$( '.project-wrap' ).hover(
		function () {
			$( this ).find( '.project-links' ).animate( { top: 0 }, 'fast' );
		},
		function () {
			$( this ).find( '.project-links' ).animate( { top: 100 + '%' }, 'fast' );
		}
	);

	// Full background image
	$( '.fx-backstretch' ).find( '.info' ).backstretch( 'assets/img/backstretch.jpg' );
});