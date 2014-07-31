# -*- encoding: utf-8 -*-

Gem::Specification.new do |s|
  s.name = "page-object"
  s.version = "1.0.2"

  s.required_rubygems_version = Gem::Requirement.new(">= 0") if s.respond_to? :required_rubygems_version=
  s.authors = ["Jeff Morgan"]
  s.date = "2014-07-21"
  s.description = "Page Object DSL that works with both Watir and Selenium"
  s.email = ["jeff.morgan@leandog.com"]
  s.homepage = "http://github.com/cheezy/page-object"
  s.licenses = ["MIT"]
  s.require_paths = ["lib"]
  s.rubyforge_project = "page-object"
  s.rubygems_version = "1.8.28"
  s.summary = "Page Object DSL for browser testing"

  if s.respond_to? :specification_version then
    s.specification_version = 4

    if Gem::Version.new(Gem::VERSION) >= Gem::Version.new('1.2.0') then
      s.add_runtime_dependency(%q<watir-webdriver>, [">= 0.6.9"])
      s.add_runtime_dependency(%q<selenium-webdriver>, [">= 2.42.0"])
      s.add_runtime_dependency(%q<page_navigation>, [">= 0.9"])
      s.add_development_dependency(%q<rspec>, ["< 3.0"])
      s.add_development_dependency(%q<cucumber>, [">= 1.3.0"])
      s.add_development_dependency(%q<yard>, [">= 0.7.2"])
      s.add_development_dependency(%q<rack>, [">= 1.0"])
    else
      s.add_dependency(%q<watir-webdriver>, [">= 0.6.9"])
      s.add_dependency(%q<selenium-webdriver>, [">= 2.42.0"])
      s.add_dependency(%q<page_navigation>, [">= 0.9"])
      s.add_dependency(%q<rspec>, ["< 3.0"])
      s.add_dependency(%q<cucumber>, [">= 1.3.0"])
      s.add_dependency(%q<yard>, [">= 0.7.2"])
      s.add_dependency(%q<rack>, [">= 1.0"])
    end
  else
    s.add_dependency(%q<watir-webdriver>, [">= 0.6.9"])
    s.add_dependency(%q<selenium-webdriver>, [">= 2.42.0"])
    s.add_dependency(%q<page_navigation>, [">= 0.9"])
    s.add_dependency(%q<rspec>, ["< 3.0"])
    s.add_dependency(%q<cucumber>, [">= 1.3.0"])
    s.add_dependency(%q<yard>, [">= 0.7.2"])
    s.add_dependency(%q<rack>, [">= 1.0"])
  end
end
