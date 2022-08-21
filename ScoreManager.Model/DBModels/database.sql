prompt PL/SQL Developer Export User Objects for user SCOTT@ORCL
prompt Created by Administrator on 2022年8月21日
set define off
spool database.log

prompt
prompt Creating table EDU_ACTION
prompt =========================
prompt
create table SCOTT.EDU_ACTION
(
  id          INTEGER not null,
  name        NVARCHAR2(20),
  description NVARCHAR2(20),
  addtime     DATE default SYSDATE not null,
  isenable    CHAR(1 CHAR) default 1 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_ACTION.id
  is '主键';
comment on column SCOTT.EDU_ACTION.name
  is '权限名称';
comment on column SCOTT.EDU_ACTION.description
  is '权限描述';
comment on column SCOTT.EDU_ACTION.addtime
  is '添加时间';
comment on column SCOTT.EDU_ACTION.isenable
  is '是否启用 0：不启用 1：启用 默认启用';
alter table SCOTT.EDU_ACTION
  add constraint EDU_ACTION_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_CLASS
prompt ========================
prompt
create table SCOTT.EDU_CLASS
(
  id       INTEGER not null,
  name     NVARCHAR2(10) not null,
  isenable CHAR(1 CHAR) default 1 not null,
  addtime  DATE default sysdate not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_CLASS.id
  is '主键';
comment on column SCOTT.EDU_CLASS.name
  is '名称';
comment on column SCOTT.EDU_CLASS.isenable
  is '是否可用 0：不可用 1：可用  默认1';
comment on column SCOTT.EDU_CLASS.addtime
  is '添加时间';
alter table SCOTT.EDU_CLASS
  add constraint EDU_CLASS_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_CLASS_TEACHER
prompt ================================
prompt
create table SCOTT.EDU_CLASS_TEACHER
(
  teacherid INTEGER not null,
  classid   INTEGER not null,
  roleid    NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_CLASS_TEACHER.teacherid
  is '教师Id';
comment on column SCOTT.EDU_CLASS_TEACHER.classid
  is '班级Id';
comment on column SCOTT.EDU_CLASS_TEACHER.roleid
  is '教师角色id';

prompt
prompt Creating table EDU_EXAM
prompt =======================
prompt
create table SCOTT.EDU_EXAM
(
  id        INTEGER not null,
  subjectid INTEGER not null,
  name      NVARCHAR2(20)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;
comment on column SCOTT.EDU_EXAM.id
  is '主键';
comment on column SCOTT.EDU_EXAM.subjectid
  is '科目Id';
comment on column SCOTT.EDU_EXAM.name
  is '考试名称';
alter table SCOTT.EDU_EXAM
  add constraint EDU_EXAM_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255;

prompt
prompt Creating table EDU_EXAMDETIAL
prompt =============================
prompt
create table SCOTT.EDU_EXAMDETIAL
(
  id        INTEGER not null,
  studentid INTEGER not null,
  examid    INTEGER not null,
  score     FLOAT default 0,
  teacherid INTEGER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;
comment on column SCOTT.EDU_EXAMDETIAL.id
  is '主键';
comment on column SCOTT.EDU_EXAMDETIAL.studentid
  is '学生id';
comment on column SCOTT.EDU_EXAMDETIAL.examid
  is '考试Id';
comment on column SCOTT.EDU_EXAMDETIAL.score
  is '分数';
comment on column SCOTT.EDU_EXAMDETIAL.teacherid
  is '冗余打分老师id';
alter table SCOTT.EDU_EXAMDETIAL
  add constraint EDU_EXAMDETIAL_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255;

prompt
prompt Creating table EDU_ROLE
prompt =======================
prompt
create table SCOTT.EDU_ROLE
(
  id          INTEGER not null,
  description NVARCHAR2(30),
  name        NVARCHAR2(10),
  addtime     DATE default SYSDATE not null,
  isenable    CHAR(1) default 1 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_ROLE.id
  is '主键';
comment on column SCOTT.EDU_ROLE.description
  is '描述';
comment on column SCOTT.EDU_ROLE.name
  is '角色名称';
comment on column SCOTT.EDU_ROLE.addtime
  is '添加时间';
comment on column SCOTT.EDU_ROLE.isenable
  is '是否启用 0：不启用 1：启用 默认启用';
alter table SCOTT.EDU_ROLE
  add constraint EDU_ROLE_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_ROLE_ACTION
prompt ==============================
prompt
create table SCOTT.EDU_ROLE_ACTION
(
  roleid   INTEGER not null,
  actionid INTEGER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_ROLE_ACTION.roleid
  is '角色id';
comment on column SCOTT.EDU_ROLE_ACTION.actionid
  is '权限id';

prompt
prompt Creating table EDU_STUDENT
prompt ==========================
prompt
create table SCOTT.EDU_STUDENT
(
  id      INTEGER not null,
  classid INTEGER,
  name    NVARCHAR2(10),
  userid  INTEGER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_STUDENT.id
  is '主键';
comment on column SCOTT.EDU_STUDENT.classid
  is '班级id';
comment on column SCOTT.EDU_STUDENT.name
  is '姓名';
comment on column SCOTT.EDU_STUDENT.userid
  is '用户id';
alter table SCOTT.EDU_STUDENT
  add constraint EDU_STUDENT_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_SUBJECT
prompt ==========================
prompt
create table SCOTT.EDU_SUBJECT
(
  id          INTEGER not null,
  name        NVARCHAR2(20),
  description NVARCHAR2(20),
  isenable    CHAR(1 CHAR) default 1 not null,
  addtime     DATE default sysdate not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_SUBJECT.id
  is '主键';
comment on column SCOTT.EDU_SUBJECT.name
  is '学科名称';
comment on column SCOTT.EDU_SUBJECT.description
  is '学科描述';
comment on column SCOTT.EDU_SUBJECT.isenable
  is '是否启用 0 不启用 1 启用默认启用';
comment on column SCOTT.EDU_SUBJECT.addtime
  is '添加时间';
alter table SCOTT.EDU_SUBJECT
  add constraint EDU_SUBJECT_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_SUGGESTIONS
prompt ==============================
prompt
create table SCOTT.EDU_SUGGESTIONS
(
  id           INTEGER not null,
  teacherid    INTEGER not null,
  studentid    INTEGER not null,
  content      NVARCHAR2(200),
  examdetailid INTEGER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;
comment on column SCOTT.EDU_SUGGESTIONS.id
  is '主键';
comment on column SCOTT.EDU_SUGGESTIONS.teacherid
  is '教师Id';
comment on column SCOTT.EDU_SUGGESTIONS.studentid
  is '学生id';
comment on column SCOTT.EDU_SUGGESTIONS.content
  is '建议内容';
comment on column SCOTT.EDU_SUGGESTIONS.examdetailid
  is '考试Id';
alter table SCOTT.EDU_SUGGESTIONS
  add constraint EDU_SUGGESTIONS_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255;

prompt
prompt Creating table EDU_TEACHER
prompt ==========================
prompt
create table SCOTT.EDU_TEACHER
(
  id            INTEGER not null,
  email_address VARCHAR2(20 CHAR),
  phone_number  VARCHAR2(11 CHAR),
  name          NVARCHAR2(10) not null,
  userid        INTEGER not null,
  subjectid     INTEGER,
  isdelete      CHAR(1) default 1 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_TEACHER.id
  is '主键';
comment on column SCOTT.EDU_TEACHER.email_address
  is '邮箱地址';
comment on column SCOTT.EDU_TEACHER.phone_number
  is '电话号码';
comment on column SCOTT.EDU_TEACHER.name
  is '老师姓名';
comment on column SCOTT.EDU_TEACHER.userid
  is '用户Id';
comment on column SCOTT.EDU_TEACHER.subjectid
  is '学科id';
comment on column SCOTT.EDU_TEACHER.isdelete
  is '是否已删除 0：已删除 1：未删除 默认1';
alter table SCOTT.EDU_TEACHER
  add constraint EDU_TEACHER_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_TEACHER_ROLE
prompt ===============================
prompt
create table SCOTT.EDU_TEACHER_ROLE
(
  teacherid INTEGER not null,
  roleid    INTEGER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_TEACHER_ROLE.teacherid
  is '教师id';
comment on column SCOTT.EDU_TEACHER_ROLE.roleid
  is '角色id';

prompt
prompt Creating table EDU_USER
prompt =======================
prompt
create table SCOTT.EDU_USER
(
  id       INTEGER not null,
  username VARCHAR2(20 CHAR) not null,
  password VARCHAR2(20 CHAR) not null,
  type     NUMBER(1) default 0 not null,
  isenable CHAR(1) default 1 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_USER.id
  is '主键';
comment on column SCOTT.EDU_USER.username
  is '登录名称';
comment on column SCOTT.EDU_USER.password
  is '密码';
comment on column SCOTT.EDU_USER.type
  is '用户类型 0：管理员 1：老师 2：学生';
comment on column SCOTT.EDU_USER.isenable
  is '是否启用 0：未启用 1：已启用  默认1';
alter table SCOTT.EDU_USER
  add constraint EDU_USER_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating sequence SEQ_ID
prompt ========================
prompt
create sequence SCOTT.SEQ_ID
minvalue 1
maxvalue 99999999
start with 150
increment by 1
nocache
order;


prompt Done
spool off
set define on
