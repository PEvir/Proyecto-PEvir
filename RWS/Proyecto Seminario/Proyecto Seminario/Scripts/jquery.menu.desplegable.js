		$(document).ready(function(){
			    $("ul.dropdown li").hide();	
			    $("ul.dropdown li.active").show();
			    var menu = $("ul.dropdown");
			    menu.mouseover(function(){
			        displayOptions($(this).find("li"));
			        $(this).find('li.active span').css('background', 'url(imagenes/dropdown2.png) no-repeat scroll right center');
			    });
			    menu.mouseout(function(){
			        hideOptions($(this));
			        $(this).find('li.active span').css('background', 'url(imagenes/dropdown.png) no-repeat scroll right center');
			    });	
			})
//funcion que MUESTRA todos los elementos del menu
function displayOptions(e){
    e.show();
}
//funcion que OCULTA los elementos del menu
function hideOptions(e){
    e.find("li").hide();
    e.find("li.active").show();
}/*
			$(document).ready(function(){ // Script del Navegador
				$("ul.dropdown li").hide();	
				$("ul.dropdown li.active").show();				
				$("ul.dropdown").toggle(
					function() { 
						$(this).find("li").show(); 
						$(this).find('li.active span').css('background', 'url(imagenes/dropdown2.png) no-repeat scroll right center');
					},
					function() {
						$('li.active').click(function(){
							$("li").hide(); 
							$("li.active").show();
							$('li.active span').css('background', 'url(imagenes/dropdown.png) no-repeat scroll right center');
						});
						
					}				
				);	
			});
			/*$(document).ready(function(){ // Script del Navegador				
				$("ul.dropdown li.active").click(
					function() { 
						$("ul.dropdown li").hide();	
						$("ul.dropdown li.active").show();
						$(this).find('li.active span').css('background', 'url(imagenes/dropdown.png) no-repeat scroll right center');
					}				
				);	
			});*/
$(document).ready(function(){ // Script del Navegador
    $("ul.subnavegador").hide();				
    $("a.desplegable").toggle(
        function() { 
            $(this).parent().find("ul.subnavegador").slideDown('slow'); 
            $(this).find('span').css('background', 'url(imagenes/dropdown2.png) no-repeat scroll right center');
        },
        function() { 
            $(this).parent().find("ul.subnavegador").slideUp('fast'); 
            $(this).find('span').css('background', 'url(imagenes/dropdown.png) no-repeat scroll right center');
        }				
    );	
});
$(document).ready(function(){  
    $("ul.subnav").parent().append("<span></span>");  
    $("ul.menu_sup li span").hover(function() {  
        $(this).parent().find("ul.subnav").slideDown('fast').show();
        $(this).parent().hover(function() {  
        }, function(){  
            $(this).parent().find("ul.subnav").slideUp('slow');
        });  
    }).hover(function() {  
        $(this).addClass("subhover");  
    }, function(){ 
        $(this).removeClass("subhover"); 
    });   
}); 
		