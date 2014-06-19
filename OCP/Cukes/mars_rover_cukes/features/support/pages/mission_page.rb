class MissionPage
  include PageObject
  
  page_url("http://localhost:53332/mission/staging")
  h3(:title, :id => "MissionControl")
  
  def get_image_at image_id
     @browser.img(:id => image_id).src	 
  end
  
end