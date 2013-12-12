(function(){var method;var noop=function(){};var methods=["assert","clear","count","debug","dir","dirxml","error","exception","group","groupCollapsed","groupEnd","info","log","markTimeline","profile","profileEnd","table","time","timeEnd","timeStamp","trace","warn"];var length=methods.length;var console=window.console=window.console||{};while(length--){method=methods[length];if(!console[method])console[method]=noop}})();
/**
 * hover animation to transition buttons
 */
var $previousTransitionButton = $('#previousTransitionButton');
var $nextTransitionButton = $('#nextTransitionButton');
var hoverTransitionHandler = function() {
  $(this).addClass('hovered').text($('.' + $(this).data('page')).data('name'));
};
var hoverTransitionClear = function() {
  $(this).removeClass('hovered').text('');
};
$previousTransitionButton.hover(hoverTransitionHandler, hoverTransitionClear);
$nextTransitionButton.hover(hoverTransitionHandler, hoverTransitionClear);
/**
 * core of animation
 */
function transition(e) {
  var $previousPage = $('.previousPage'),
    $currentPage = $('.currentPage'),
    $nextPage = $('.nextPage'),
    $hiddenPage = null,
    hiddenPageID = null,
    pagesNumber = $('.page').length;

  if (e.data.reverse == true) {
    numcapa = $('.previousPage').data('index');
  } else {
    numcapa = $('.nextPage').data('index');
  }

  $('.main-links li').removeClass('active');
  if(numcapa == "2") { $('#us2').addClass('active'); }
  if(numcapa == "3") { $('#our-products2').addClass('active'); }
  if(numcapa == "4") { $('#research2').addClass('active'); }
  if(numcapa == "5") { $('#contact2').addClass('active'); }
  if(numcapa == "6") { $('#be-our-client2').addClass('active'); }
  if(numcapa == "1") {}

  var effect = function (page, time, additionalTimeSign, left, delay, ease) {
    $(page + ' .transitionElement').delay(delay).each(function(index) {
      $(this).animate({
        left: left
      }, time + (additionalTimeSign * (index * time / 6)), ease);
    });
  };
  var effectTime = 500,
    ease = 'easeInExpo';
  var previousTransition = function() {
    effect('.currentPage', effectTime + 120, -1, '100%', 0, ease);
    effect('.previousPage', effectTime + 120, -1, 0, effectTime / 2, ease);
  };
  var nextTransition = function(){
    effect('.currentPage', effectTime, 1, '-100%', 0, ease);
    effect('.nextPage', effectTime, 1, 0, effectTime / 2, ease);
  };
  var resetTransition = function() {
    $('.transitionElement').removeAttr('style');
  }
  var classChange = function (element, currentClass, newClass) {
    element.removeClass(currentClass).addClass(newClass);
  };
  var transitionUpdate = function(delay) {
    setTimeout(function(){
      $hiddenPage = $('.page[data-index=' + hiddenPageID + ']');
      classChange($previousPage, 'previousPage', e.data.exchangePreviousPage);
      classChange($currentPage, 'currentPage', e.data.exchangeCurrentPage);
      classChange($nextPage, 'nextPage', e.data.exchangeNextPage);
      classChange($hiddenPage, 'hiddenPage', e.data.exchangeHiddenPage);
      resetTransition();
    }, delay);
    
    
  };
  var hoverTransitionClear = function() {
    if (e.currentTarget != undefined) {
      $('#' + e.currentTarget.id).removeClass('hovered').text('');
    } else {
      console.log('Special Transition');
    }
  };
  if (e.data.reverse == true) {
    previousTransition();
    hiddenPageID = $previousPage.data('index') > 1 ? ($previousPage.data('index') - 1) : pagesNumber;
  } else {
    nextTransition();
    hiddenPageID = $nextPage.data('index') < pagesNumber ? ($nextPage.data('index') + 1) : 1;
  }


  transitionUpdate(effectTime * 2.5);
  /**
   * hover transition clear
   */
  hoverTransitionClear();  
}
/**
 * load events and transitions
 */
$('#previousTransitionButton').on('click', {
  reverse: true,
  exchangePreviousPage: 'currentPage',
  exchangeCurrentPage: 'nextPage',
  exchangeNextPage: 'hiddenPage',
  exchangeHiddenPage: 'previousPage'
}, transition);

$('#nextTransitionButton').on('click', {
  exchangePreviousPage: 'hiddenPage',
  exchangeCurrentPage: 'previousPage',
  exchangeNextPage: 'currentPage',
  exchangeHiddenPage: 'nextPage'
}, transition);
/**
 * Special transition to nav
 */
var $mainLink = $('.main-links2 a');
//var $mainLink2 = $('#home a');

function specialTransition(vartmp) {

  var currentPageIndex = $('.currentPage').data('index');

  if(vartmp == "[object Object]"){
    var page = $(this).attr('href').slice(1);
  }
  else {
    var page = vartmp;
  }
  

  var $page = $('.' + page);
  var pageIndex = $('.' + page).data('index');
  var transitionSetting = {};

  $('.main-links li').removeClass('active');
  $('#' + page +"2").addClass('active');


  var previousTransitionSetting = {
    reverse: true,
    exchangePreviousPage: 'currentPage',
    exchangeCurrentPage: 'nextPage',
    exchangeNextPage: 'hiddenPage',
    exchangeHiddenPage: 'previousPage'
  };
  var nextTransitionSetting = {
    exchangePreviousPage: 'hiddenPage',
    exchangeCurrentPage: 'previousPage',
    exchangeNextPage: 'currentPage',
    exchangeHiddenPage: 'nextPage'
  };
  if (currentPageIndex != pageIndex) {
    if (currentPageIndex < pageIndex) {
      /**
       * next transition
       */
      $('.nextPage').addClass('hiddenPage').removeClass('nextPage');
      if (!$page.hasClass('nextPage')) {
        $page.addClass('nextPage').removeClass('previousPage').removeClass('hiddenPage');
      }
      transitionSetting = nextTransitionSetting;
    } else {
      /**
       * previous transition
       */
      $('.previousPage').addClass('hiddenPage').removeClass('previousPage');
      if (!$page.hasClass('previousPage')) {
        $page.addClass('previousPage').removeClass('nextPage').removeClass('hiddenPage');
      }
      transitionSetting = previousTransitionSetting;
    }
    transition({data: transitionSetting});
    setTimeout(function(){
      $('.nextPage').addClass('hiddenPage').removeClass('nextPage');
      $('.previousPage').addClass('hiddenPage').removeClass('previousPage');
      var lasPageIndex = $('.page').length;
      var previousPageIndex, nextPageIndex;
      previousPageIndex = (pageIndex - 1) >= 1 ? (pageIndex - 1) : lasPageIndex;
      nextPageIndex = (pageIndex + 1) <= lasPageIndex ? (pageIndex + 1) : 1;
      // previous page setting
      $('.page[data-index=' + previousPageIndex + ']').addClass('previousPage').removeClass('hiddenPage');
      // next page setting
      $('.page[data-index=' + nextPageIndex + ']').addClass('nextPage').removeClass('hiddenPage');
    }, 500 * 2.6); // time effect transition => 500 * 2.5
  }

}

$mainLink.on('click', specialTransition);

//$mainLink2.on('click', specialTransition);

function reset_form(e) {
  $(e.data.selector)[0].reset();
}
$('#contact-form .cleanButton').on('click', {
  selector: '#contact-form'
}, reset_form);
/**
 * example of show modal experts
 */
/*
$('.modal.show-experts .hideButton').on('click', function(){
  $('.modal').hide();
});
$('.internal-page.us-our-experts>.body>.span-8-of-12>.wrapper>.container>img').on('click', function(){
  $('.modal').show();
});
*/

var param = document.URL.split('#')[1];
  
if(typeof param === "undefined")
{
    //alert("ingreso");
    //var page = "home"; 
}
else{
    specialTransition(param);  
}