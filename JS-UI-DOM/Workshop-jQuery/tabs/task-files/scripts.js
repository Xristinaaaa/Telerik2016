$.fn.tabs = function () {
    var $tabControl=this;
    $tabControl.addClass('tabs-container');
    hideContent();

    $tabControl.on('click', '.tab-item-title', function(){
        var $currentItem= $(this);
        hideContent();
        $tabControl.find('.tab-item').removeClass('current');
        $currentItem.next().show();
        $currentItem.parent().addClass('current');
    });

    function hideContent(){
        $tabControl.find('.tab-item-content').hide();
    }
    return this;    
};