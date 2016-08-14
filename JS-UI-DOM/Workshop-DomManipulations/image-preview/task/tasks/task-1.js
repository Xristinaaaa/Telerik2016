/* globals module */
function solve() {
    return function (selector, items) {
      var root=document.querySelector(selector);
      var fragment=document.createDocumentFragment();

      var imagePreviewer=document.createElement('div');
      imagePreviewer.style.width='80%';
      imagePreviewer.style.textAlign='center';    
      imagePreviewer.style.float='left'; 
      imagePreviewer.style.display='inline-block';

      var selectedParent=document.createElement('div');
      selectedParent.classList.add('image-preview');
      var selectedImageHeader=document.createElement('h3');
      selectedImageHeader.innerText=items[0].title;
      var selectedImage=document.createElement('img');
      selectedImage.src=items[0].url;
      selectedImage.style.width='80%';

      selectedParent.appendChild(selectedImageHeader);
      selectedParent.appendChild(selectedImage);
      imagePreviewer.appendChild(selectedParent);

      var aside=document.createElement('div');
      aside.style.width='30%';      
      aside.style.textAlign='center';
      aside.style.display='inline-block';

      var filterInput=document.createElement('input');
      var inputHeader=document.createElement('h3');
      inputHeader.innerText('Filter');
      filterInput.addEventListener('keyup', function(ev){
          var text=ev.target.value;
          var liChildren=asideContainder.getElementsByTagName('li');
          for (var i = 0, len=liChildren.length; i < len; i+=1) {
              var currentLi=liChildren[i];
              var header=currentLi.firstElementChild.innerText;
              if(header.toLowerCase().indexOf(text.toLowerCase())>=0){
                  currentLi.style.display='block';
              }
              else{
                  currentLi.style.display='none';
              }
          }
      }, false);
      aside.appendChild(inputHeader);
      aside.appendChild(filterInput);

      var asideContainder=document.createElement('ul');
      asideContainder.style.listStyleType='none';
      asideContainder.style.height='500px';
      asideContainder.style.overflowY='scroll';

      asideContainder.addEventListener('click', function(ev){
          var target=ev.target;
          if(target.tagName==='IMG'){
              var header=target.previousElementSibling.innerText;
              var source=target.src;
              selectedImageHeader.innerText=header;
              selectedImageHeader.src=source;
          }
      }, false);

      asideContainder.addEventListener('mouseover', function(ev){
          var target = ev.target;
          if(target.tagName==='IMG'){
              target.parentElement.style.backgroundColor='gray';
              target.parentElement.style.cursor='pointer';
          }
      }, false);

      asideContainder.addEventListener('mouseout', function (ev) {
          var target=ev.target;
          if(target.tagName==='IMG'){
              target.parentElement.style.backgroundColor='';
          }
     }, false);

      var li=document.createElement('li');
      li.classList.add('image-container');
      var imageHeader=document.createElement('h3');
      var image=document.createElement('img');
      image.style.width='90%';
      for (var i = 0, len= items.length; i < len; i+=1) {
          var currentElement=items[i];
          var currentli=li.cloneNode(true);
          var header=imageHeader.cloneNode(true);
          header.innerText=currentElement.title;
          var imageContainer=image.cloneNode(true);
          imageContainer.src=currentElement.url;

          currentli.appendChild(header);
          currentli.appendChild(imageContainer);

          asideContainder.appendChild(currentli);
      }
      aside.appendChild(asideContainder);

      fragment.appendChild(imagePreviewer);
      fragment.appendChild(aside);
      root.appendChild(fragment);
    };
}

module.exports = solve;