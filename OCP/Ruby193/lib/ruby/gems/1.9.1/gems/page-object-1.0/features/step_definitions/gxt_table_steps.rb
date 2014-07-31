Given /^I am on the Gxt Examples page$/ do
  visit GxtSamplePageObject
end

When /^I have the Basic Grid opened$/ do
  on(GxtSamplePageObject).basic_grid_element.click
end

When /^I have defined a GxtTable class extending Table$/ do
  class GxtTable < PageObject::Elements::Table

    def self.accessor_methods(accessor, name)
      accessor.send :define_method, "#{name}_rows" do
        self.send("#{name}_element").rows
      end
    end
    
    protected
      def child_xpath
        ".//descendant::tr"
      end
  end
end

When /^I define a page-object using that widget$/ do
  class GxtSamplePageObject
    include PageObject

    page_url "http://gxtexamplegallery.appspot.com/"

    div(:basic_grid, :class => "label_basic_grid")
    gxt_table(:gxt_table, :class => "x-grid3")
  end
end

When /^I have registered the GxtTable with PageObject$/ do
  PageObject.register_widget :gxt_table, GxtTable, 'div'
end

When /^I retrieve a GxtTable widget$/ do
  @element = on(GxtSamplePageObject).gxt_table_element
end


When /^the GxtTable should have "(\d+)" rows$/ do |rows|
  on(GxtSamplePageObject).gxt_table_rows.should == rows.to_i
end

